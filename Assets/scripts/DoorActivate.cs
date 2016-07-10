using UnityEngine;
using System.Collections;

public class DoorActivate : MonoBehaviour {

    private Quaternion startRot;
    public Transform endRot;
    private bool lerping;
    private bool opening;

    // Use this for initialization
    void Start() {
        startRot = transform.localRotation;
    }

    void Update() {
        // Update is called once per frame
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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
                transform.localRotation = Quaternion.Lerp(transform.localRotation, endRot.localRotation, Time.deltaTime * 3);
            } else {
                transform.localRotation = Quaternion.Lerp(transform.localRotation, startRot, Time.deltaTime * 3);
            }
        }
    }
}
