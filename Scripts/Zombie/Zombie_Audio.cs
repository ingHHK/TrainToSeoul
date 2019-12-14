using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Audio : MonoBehaviour
{
    //audio Index = 0: Idle, 1: Attack, 2: Die
    public AudioClip idle;
    public AudioClip attack;
    public AudioClip die;
    private AudioSource audio;
    private float wait = 0;

    public void setIdle(){
        audio.clip = idle;
        audio.volume = 0.02f;
    }

    public void setAttack(){
        audio.clip = attack;
        audio.volume = 0.2f;
        audio.Play();
    }
   
    public void setDie(){
        audio.clip = die;
        audio.volume = 0.1f;
        audio.Play();
    }

    void Awake(){
        audio = GetComponent<AudioSource>();
        audio.volume = 0.02f;
        audio.clip = idle;
    }

    void Update(){
        if(wait >= 2.0f){
            audio.Play();
            wait = 0;
            setIdle();
        }
        wait += Time.deltaTime;
    }
}