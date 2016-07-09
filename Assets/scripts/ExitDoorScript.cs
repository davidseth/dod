using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExitDoorScript : MonoBehaviour {

    public AllScripts allScripts;

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
                    if (hit.distance < 2) {
                        //play relived sound
                        StartCoroutine("ExitGame");
                    }
                }
            }
        }
    }

    IEnumerator ExitGame() {
        StartCoroutine("ExitFadeToBlack");
        yield return new WaitForSeconds(2.5f);
        Application.Quit();
    }

    IEnumerator ExitFadeToBlack() {
        Image fadeColour = allScripts.cameraFade.FadeImg;
        fadeColour.enabled = true;
        while (true) {
            yield return new WaitForSeconds(0.1f);
            fadeColour.color = Color.Lerp(fadeColour.color, Color.black, 10 * Time.deltaTime);
        }
    }
}
