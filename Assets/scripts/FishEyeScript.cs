using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
public class FishEyeScript : MonoBehaviour {

    public AllScripts allScript;
    public float intensity, increaseSpeed;
    public bool stopping, decreasing;
    private Fisheye fishEyeScript;


    // Use this for initialization
    void Start() {
        fishEyeScript = allScript.mainCam.GetComponent<Fisheye>();
    }

    void Update() {
        if (!stopping) {
            if (intensity <= 0.95f) {
                intensity = intensity + intensity * Time.deltaTime * increaseSpeed;
            } else {
                allScript.gameManager.Ded();
            }
        } else {//if stopping
            if (intensity < 1f) {
                intensity = Mathf.Lerp(intensity, 0f, Time.deltaTime);
            }
        }
        fishEyeScript.strengthX = intensity;
    }
}
