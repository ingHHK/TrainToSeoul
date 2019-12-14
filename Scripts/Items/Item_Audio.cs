using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Audio : MonoBehaviour
{
    public AudioClip Serum;
    public AudioClip HPKit;
    public AudioClip item;

    private AudioSource audio;
    private float wait = 0;

    public void sound_Serum(){
        audio.clip = Serum;
        audio.volume = 0.5f;
        audio.Play();
        Debug.Log("sound Serum");
    }

    public void sound_HPkit(){
        audio.clip = HPKit;
        audio.volume = 0.5f;
        audio.Play();
        Debug.Log("sound HPkit");
    }

    public void sound_Item(){
        audio.clip = item;
        audio.volume = 0.5f;
        audio.Play();
        Debug.Log("sound Item");
    }

    void Start(){
        audio = GetComponent<AudioSource>();
    }
}
