using UnityEngine;
using System.Collections;

public class AnimateBloom : MonoBehaviour {
    public float floor = 0f;
    public float ceiling = 0.2f;
    public float speed = 0.5f;
    public Color baseColor = Color.red;
    void Update() {
        Renderer renderer = GetComponent<Renderer>();
        Material mat = renderer.material;

        float emission = floor + Mathf.PingPong(Time.time * speed, ceiling - floor);
         //Replace this with whatever you want for your base color at emission level '1'
        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);
        mat.SetColor("_EmissionColor", finalColor);
        //Debug.Log(mat.GetColor("_EmissionColor"));
    }
}
