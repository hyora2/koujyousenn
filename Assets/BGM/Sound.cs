using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

    public AudioClip GameOver;
    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
