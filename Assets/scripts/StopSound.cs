using UnityEngine;
using System.Collections;

public class StopSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.F)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.gameObject == gameObject) {
                    if (hit.distance < 2) {
                        if(GetComponent<AudioSource>().volume == 1)
                            GetComponent<AudioSource>().volume = 0;
                        else
                            GetComponent<AudioSource>().volume = 1;
                    }
                }
            }
        }
    }
}
