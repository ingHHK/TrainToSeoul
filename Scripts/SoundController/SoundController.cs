using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{   
    //Item Sound
    public AudioClip serum;
    public AudioClip HPKit;
    public AudioClip item;
    //Player Die
    public AudioClip Player_Die;
    //Boss Zombie Die
    public AudioClip Boss_Die;
    //Zombie Die
    public AudioClip Zombie_Die;
    //GameController
    public AudioClip alarm;

    private AudioSource audio;

    public void boss_die(){
        audio.clip = Boss_Die;
        audio.volume = 0.8f;
        audio.Play();
    }

    public void zombie_die(){
        audio.clip = Zombie_Die;
        audio.volume = 0.2f;
        audio.Play();
    }

    public void Serum(){
        audio.clip = serum;
        audio.volume = 0.2f;
        audio.Play();
        Debug.Log("sound Serum");
    }

    public void HPkit(){
        audio.clip = HPKit;
        audio.volume = 0.4f;
        audio.Play();
        Debug.Log("sound HPkit");
    }

    public void Item(){
        audio.clip = item;
        audio.volume = 0.2f;
        audio.Play();
        Debug.Log("sound Item");
    }

    public void player_die(){
        audio.clip = Player_Die;
        audio.volume = 0.8f;
        audio.Play();
    }

    public void Alarm(){
        audio.volume = 0.8f;
        audio.clip = alarm;
        audio.Play();
        
    }

    public void StartAlarm(){
        audio.volume = 0.8f;
        audio.clip = alarm;
    }

    void Awake(){
        audio = GetComponent<AudioSource>();
    }
}
