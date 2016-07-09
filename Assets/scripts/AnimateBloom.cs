using UnityEngine;
using System.Collections;

public class AnimateBloom : MonoBehaviour {

    void Update() {
        Renderer renderer = GetComponent<Renderer>();
        Material mat = renderer.material;
        float floor = 0.5f;
        float ceiling = 1f;
        float emission = floor + Mathf.PingPong(Time.time, ceiling - floor);
        Color baseColor = Color.red; //Replace this with whatever you want for your base color at emission level '1'
        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);
        mat.SetColor("_EmissionColor", finalColor);
        //Debug.Log(mat.GetColor("_EmissionColor"));
    }
}
