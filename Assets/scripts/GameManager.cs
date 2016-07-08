using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour {

    public AllScripts allScript;
    public FirstPersonController fpc;
    public bool[] drugs;
    private bool ded;

	// Use this for initialization
	void Start () {
        fpc = FindObjectOfType<FirstPersonController>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void DrugTaken(int drugIndex, GameObject pill) {
        drugs[drugIndex] = true;
        for(int i = 0; i < drugIndex; i++) {
            if(drugs[i] == false) {
                if (pill.name == "WobblePill") {
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
        Debug.Log("all good");
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
            Debug.Log(vel);
        }

        //fade to black
    }
}
