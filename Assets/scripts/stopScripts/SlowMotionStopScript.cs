using UnityEngine;
using System.Collections;

public class SlowMotionStopScript : MonoBehaviour {

    public AllScripts allScripts;
    public int drugOrder;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = allScripts.mainCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) { 
                if (hit.collider.gameObject == gameObject) {
                    if(hit.distance < 2) {
                        //play relived sound
                        allScripts.slowMoScript.stopping = true;
                        allScripts.gameManager.DrugTaken(drugOrder, gameObject);
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
