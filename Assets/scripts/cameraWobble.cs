using UnityEngine;
using System.Collections;

public class CameraWobble : MonoBehaviour {

    public AllScripts allScript;
    public Transform cam;
    public float intensity;
    private float increase = 0.015f, speed = 5;
    public bool stopping;


    // Use this for initialization
    void Start() {

        
    }

    void LateUpdate() {
        if (!stopping){
            if (intensity <= 0.9) {
                intensity = intensity + intensity * Time.deltaTime * 0.03f;
            } else {
                //ded
            }
        } else {//if stopping
            intensity = Mathf.Lerp(intensity, 0, Time.deltaTime);
            //if()
        }

        transform.rotation = Quaternion.Lerp(cam.rotation, transform.rotation * Quaternion.Euler(Mathf.Sin(Time.time * speed * 0.6f) * 1.6f, Mathf.Sin(Time.time * speed * 0.8f) * 1.6f, Mathf.Sin(Time.time * speed)*2), intensity);
    }
}
