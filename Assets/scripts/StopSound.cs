using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StopSound : MonoBehaviour {

    public float maxVolume;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.gameObject == gameObject) {
                    if (hit.distance < 2) {
                        if (GetComponent<AudioSource>().volume >= 0.1f)
                            GetComponent<AudioSource>().volume = 0;
                    }
                }
            }
        }
    }
}
