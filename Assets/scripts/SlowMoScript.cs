using UnityEngine;
using System.Collections;

public class SlowMoScript : MonoBehaviour {

    public AllScripts allScript;
    public float intensity, increaseSpeed =1;
    public bool stopping, decreasing;


    // Use this for initialization
    void Start() {

    }

    void Update() {
        if (!stopping) {
            if (decreasing) {
                if (intensity <= 0.3f) {
                    intensity = intensity + intensity * Time.deltaTime * 0.12f;
                } else {
                    decreasing = false;
                }
            } else {
                if (intensity > 0.5f) {
                    intensity -= Time.deltaTime * 0.04f * increaseSpeed;
                } else if (intensity > 0.2f) {
                    intensity -= Time.deltaTime * 0.08f * increaseSpeed;
                } else if (intensity > 0.1) {
                    intensity -= Time.deltaTime * 0.16f * increaseSpeed;
                } else {
                    allScript.gameManager.Ded();
                    stopping = true;
                }
            }
        } else {//if stopping
            if (intensity < 1f) {
                intensity = Mathf.Lerp(intensity, 1.1f, Time.deltaTime);
            }
        }
        Time.timeScale = intensity;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        allScript.mainMusic.pitch = Time.timeScale;
        allScript.alarm.pitch = Time.timeScale;
    }
}
