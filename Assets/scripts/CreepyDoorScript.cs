using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreepyDoorScript : MonoBehaviour {

    private bool hasPlayed;
    public AudioClip[] knocks;
    public AudioClip[] creepyManSounds;
    public AudioSource knockAudio, manAudio;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && !hasPlayed) {
            int intensity = SceneManager.GetActiveScene().buildIndex;
            Debug.Log(intensity);
            knockAudio.clip = knocks[intensity];
            manAudio.clip = creepyManSounds[intensity];
            knockAudio.Play();
        }
    }
    void OnTriggerExit(Collider other) {
        if (other.tag == "Player" && !hasPlayed) {
            knockAudio.Stop();
            manAudio.Play();
            hasPlayed = true;
        }
    }
}
