using UnityEngine;
using System.Collections;

public class SlowMoScript : MonoBehaviour {

    public AllScripts allScript;
    public float intensity;
    public bool stopping;


    // Use this for initialization
    void Start() {

    }

    void Update() {
        if (!stopping) {
            if (intensity > 0.5f) {
                intensity -= Time.deltaTime * 0.025f;
            } else if (intensity > 0.2f) {
                intensity -= Time.deltaTime * 0.045f;
            } else if (intensity > 0.1) {
                intensity -= Time.deltaTime * 0.085f;
            } else {
                allScript.gameManager.Ded();
                stopping = true;
            }
        } else {//if stopping
            if (intensity < 1f) {
                intensity = Mathf.Lerp(intensity, 1.1f, Time.deltaTime);
            }
        }
        Time.timeScale = intensity;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}
