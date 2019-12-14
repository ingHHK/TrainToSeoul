using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Point : MonoBehaviour
{
    GameObject zombie;
    GameObject player;
    bool zombieInRange = false;
    CompleteProject.PlayerHealth hp;

    void Start(){
        zombie = GameObject.FindGameObjectWithTag ("Zombie");
        player = GameObject.FindGameObjectWithTag ("Player");
        hp = player.GetComponent<CompleteProject.PlayerHealth>();
    }
    
    void Update(){
        if(zombieInRange){
            hp.TakeDamage(hp.currentHealth);
        }
    }
    
    void OnTriggerEnter (Collider other){
        // If the entering collider is the zombie...
        if(other.gameObject.tag == "Zombie"){
        // ... the zombie is in range.
            zombieInRange = true;
        }
    }
}
