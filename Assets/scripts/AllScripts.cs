using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class AllScripts : MonoBehaviour {

    public CameraWobble cameraWobble;
    public SlowMoScript slowMoScript;
    public FishEyeScript fishEyeScript;
    public Camera mainCam;
    public GameManager gameManager;
    public CharacterController characterController;
    public Rigidbody firstPersonRigid;
    public Bloom bloom;
    public CameraFade cameraFade;
    public AudioSource mainMusic, alarm;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
