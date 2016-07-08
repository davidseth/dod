using UnityEngine;
using System.Collections;

public class CameraWobbleStop : MonoBehaviour {

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
                        Debug.Log(hit.distance);
                        //play relived sound
                        allScripts.cameraWobble.stopping = true;
                        allScripts.gameManager.DrugTaken(drugOrder, gameObject);
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
