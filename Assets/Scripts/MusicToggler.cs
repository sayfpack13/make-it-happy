using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicToggler : MonoBehaviour
{
    public AudioClip endclip;

    public void startmusic()
    {
        GetComponent<AudioSource>().Play();
    }

    public void stopmusic()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = endclip;
        GetComponent<AudioSource>().Play();
    }
}
