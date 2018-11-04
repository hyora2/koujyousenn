using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    private AudioSource[] audios;

    // Use this for initialization
    void Start()
    {
        audios = GetComponents<AudioSource>();
        audios[0].Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            audios[1].Play();
            SceneManager.LoadScene("Title");
        }
    }
}
