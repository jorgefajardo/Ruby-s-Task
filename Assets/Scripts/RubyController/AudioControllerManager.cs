using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AudioControllerManager : MonoBehaviour
{

    public AudioClip enviorement, enviorementq, envioremente, loser, win;
    public AudioSource audio;
    public TMP_Text text;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            audio.clip = enviorementq;
            audio.Play();
            text.text = "Alt Music 2";
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            text.text = "";
            audio.clip = enviorement;
            audio.Play();

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            audio.clip = envioremente;
            text.text = "Alt Music 3";
            audio.Play();

        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            text.text = "";
            audio.clip = enviorement;
            audio.Play();

        }
    }

    public void Loser()
    {
        audio.clip = loser;
        audio.Play();
        audio.loop = false;
    }

    public void Win()
    {
        audio.clip = win;
        audio.Play();
        audio.loop = false;
    }
}
