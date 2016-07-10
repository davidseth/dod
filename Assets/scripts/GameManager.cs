using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour {

    public AllScripts allScript;
    FirstPersonController fpc;
    CameraFade cameraFade;
    public bool[] drugs;
    private bool ded;

    // Use this for initialization
    void Start() {
        Debug.Log("hello ");

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
        Debug.Log("eaten pill");
        drugs[drugIndex] = true;
        //for (int i = 0; i < drugIndex; i++) {
        //    if (drugs[i] == false) {
        //        if (pill.name == "WobblePill") {
        //            Debug.Log("uh oh" + pill.name);
        //            allScript.cameraWobble.intensity = 0.8f;
        //            allScript.cameraWobble.stopping = false;
        //            allScript.cameraWobble.decreasing = true;
        //        } else if (pill.name == "SlowMoPill") {
        //            Debug.Log("uh oh" + pill.name);
        //            allScript.cameraWobble.intensity = 0.8f;
        //            allScript.cameraWobble.stopping = false;
        //            allScript.cameraWobble.decreasing = true;
        //        }
        //        allScript. increase effect 
        //        Ded();
        //        return;
        //    }
        //}
        Debug.Log("might noit win");
        for (int i = 0; i < drugs.Length; i++) {
            if (drugs[i] == false) {
                return;
            }
        }
        if (allScript.cameraWobble != null)
            allScript.cameraWobble.decreasing = true;
        if (allScript.slowMoScript != null)
            allScript.slowMoScript.decreasing = true;
        if (allScript.fishEyeScript != null)
            allScript.fishEyeScript.decreasing = true;
        //win
        //no more effects
        //fade to black
        Debug.Log("win");
        allScript.bloom.bloomThreshold = 0.2f;
        allScript.bloom.bloomIntensity = 2f;
        StartCoroutine("LoadingNextLevel");
    }

    IEnumerator LoadingNextLevel() {
        yield return new WaitForSeconds(2);
        cameraFade.EndScene("main");
        yield return new WaitForSeconds(1.5f);
        if (SceneManager.GetActiveScene().buildIndex != 2)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        else
            SceneManager.LoadScene(0, LoadSceneMode.Single);
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
            StartCoroutine("Dying");
        }
    }
    IEnumerator Dying() {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
