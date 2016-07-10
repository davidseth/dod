using UnityEngine;
using System.Collections;

public class AnimateLightIntensity : MonoBehaviour {
    public float floor = 0f;
    public float ceiling = 0.2f;
    public float speed = 0.5f;

    void Update() {
        Light light = GetComponent<Light>();

        float emission = floor + Mathf.PingPong(Time.time * speed, ceiling - floor);
        //Replace this with whatever you want for your base color at emission level '1'
        light.intensity = emission;
        //Debug.Log(mat.GetColor("_EmissionColor"));
    }
}
