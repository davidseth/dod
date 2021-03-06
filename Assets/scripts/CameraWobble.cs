﻿using UnityEngine;
using System.Collections;

public class CameraWobble : MonoBehaviour {

    public AllScripts allScript;
    public Transform cam;
    public float intensity, increaseSpeed = 0.05f;
    private float speed = 5;
    public bool stopping, decreasing;


    // Use this for initialization
    void Start() {

        
    }

    void LateUpdate() {
        if (!stopping){
            if(decreasing) {
                if (intensity >= 0.7f) {
                    intensity = intensity - intensity * Time.deltaTime * 0.09f;
                } else {
                    decreasing = false;
                }
            }
            if (intensity <= 0.95f) {
                intensity = intensity + intensity * Time.deltaTime * increaseSpeed;
            } else {
                allScript.gameManager.Ded();
            }
        } else {//if stopping
            intensity = Mathf.Lerp(intensity, 0, Time.deltaTime);
        }

        transform.rotation = Quaternion.Lerp(cam.rotation, transform.rotation * Quaternion.Euler(Mathf.Sin(Time.time * speed * 0.6f) * 1.6f, Mathf.Sin(Time.time * speed * 0.8f) * 1.6f, Mathf.Sin(Time.time * speed)*2), intensity);
    }

}
