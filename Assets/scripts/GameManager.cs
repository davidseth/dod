using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour {

    public AllScripts allScript;
    public FirstPersonController fpc;
    CameraFade cameraFade;
    public bool[] drugs;
    private bool ded;

    // Use this for initialization
    void Start() {
        fpc = FindObjectOfType<FirstPersonController>();
        cameraFade = GameObject.FindObjectOfType<CameraFade>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void DrugTaken(int drugIndex, GameObject pill) {
        drugs[drugIndex] = true;
        for (int i = 0; i < drugIndex; i++) {
            if (drugs[i] == false) {
                if (pill.name == "WobblePill") {
                    Debug.Log("uh oh" + pill.name);
                    allScript.cameraWobble.intensity = 0.8f;
                    allScript.cameraWobble.stopping = false;
                    allScript.cameraWobble.decreasing = true;
                } else if (pill.name == "SlowMoPill") {
                    Debug.Log("uh oh" + pill.name);
                    allScript.cameraWobble.intensity = 0.8f;
                    allScript.cameraWobble.stopping = false;
                    allScript.cameraWobble.decreasing = true;
                }
                //allScript. increase effect 
                //Ded();
                return;
            }
        }

        for (int i = 0; i < drugs.Length; i++) {
            if (drugs[i] == true) {
                return;
            }
        }
        if (allScript.cameraWobble != null)
            allScript.cameraWobble.decreasing = true;
        if (allScript.slowMoScript != null)
            allScript.slowMoScript.decreasing = true;
        //win
        //no more effects
        //fade to black
        allScript.bloom.bloomThreshold = 0.2f;
        allScript.bloom.bloomIntensity = 2f;
        StartCoroutine("LoadingNextLevel");
    }

    IEnumerator LoadingNextLevel() {
        cameraFade.EndScene("main");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }

    public void Ded() {
        if (!ded) {
            ded = true;
            Rigidbody body = fpc.GetComponent<Rigidbody>();
            var vel = body.velocity;
            body.isKinematic = false;
            fpc.GetComponent<CharacterController>().enabled = false;
            fpc.GetComponent<FirstPersonController>().enabled = false;
            body.AddTorque(vel + new Vector3(20, 0, 0));
            //fade to black
            cameraFade.EndScene("main");
        }
    }
}
