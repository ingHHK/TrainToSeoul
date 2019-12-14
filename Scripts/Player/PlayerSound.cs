using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioClip walk;

    private AudioSource audio;
    private int player_state = 0; //0:stop, 1:walk, 2:run
    private float wait = 0;

    public void setState(int state){
        player_state = state;
    }

    void set_stop(){
        audio.Stop();
    }

    void set_walk(){
        audio.clip = walk;
        audio.Play();
    }

    void Start(){
        audio = GetComponent<AudioSource>();
        audio.volume = 0.1f;
    }

    void Update(){
        switch (player_state){
            case 0: //stop
                set_stop();
                break;
            case 1: //walk
                if(wait >= 0.3f){
                    set_walk();
                    wait = 0;
                }
                break;
            case 2: //run
                if(wait >= 0.15f){
                    set_walk();
                    wait = 0;
                }
                break;
        }
        wait += Time.deltaTime;
    }
}