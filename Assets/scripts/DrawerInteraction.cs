using UnityEngine;
using System.Collections;

public class DrawerInteraction : MonoBehaviour {

    public AllScripts allScripts;
    public float distance;
    private bool opening, lerping;
    private Vector3 endPos, startPos;

	// Use this for initialization
	void Start () {
        startPos = transform.localPosition;
        endPos = transform.localPosition + new Vector3(0, 0, distance);
        //transform.localPosition = endPos;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = allScripts.mainCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.gameObject == gameObject) {
                    if (hit.distance < 2) {
                        if (!opening) {
                            opening = true;
                        } else {
                            opening = false;
                        }
                        lerping = true;
                    }
                }
            }
        }
        if (lerping) {
            if (opening) {
                if (transform.localPosition.z >= endPos.z - 0.005f) {
                    lerping = false;
                    opening = false;
                } else {
                    transform.localPosition = Vector3.Lerp(transform.localPosition, endPos, Time.deltaTime * 3);
                }
            } else {
                if (transform.localPosition.z <= startPos.z + 0.005f) {
                    lerping = false;
                    opening = true;
                } else {
                    transform.localPosition = Vector3.Lerp(transform.localPosition, startPos, Time.deltaTime * 3);
                }
            }
        }
    }
}
