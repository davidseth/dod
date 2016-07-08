using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    AllScripts allScript;
    public bool[] drugs;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void DrugTaken(int drugIndex) {
        drugs[drugIndex] = true;
        for(int i = 0; i < drugIndex; i++) {
            if(drugs[i] == false) {
                Debug.Log("oops");
                return;
            }
        }
        Debug.Log("all good");
    }
}
