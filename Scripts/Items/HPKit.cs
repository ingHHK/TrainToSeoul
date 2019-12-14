using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CompleteProject
{
    public class HPKit : MonoBehaviour
    {
        public GameObject HPUI;
        GameObject player;
        PlayerHealth playerHealth;
        GameObject soundController;
        SoundController audio;
        bool playerInRange = false;

        // Start is called before the first frame update
        void Awake(){
            player = GameObject.FindGameObjectWithTag ("Player");   
            playerHealth = player.GetComponent <PlayerHealth> ();
            soundController = GameObject.FindGameObjectWithTag("SoundController");
            audio = soundController.GetComponent<SoundController>();
        }

        // Update is called once per frame
        void Update(){
            transform.Rotate(new Vector3 (0 , 90, 0) * Time.deltaTime, Space.World);
            if(playerInRange) {
                audio.HPkit();
                HPUI.SetActive(true);
                if(playerHealth.currentHealth > 8) {
                    playerHealth.currentHealth = 10;
                }
                else{
                    playerHealth.currentHealth += 2;
                }
                Destroy(gameObject);
            }
        }
        
        void OnTriggerEnter (Collider other){
                // If the entering collider is the player...
            if(other.gameObject == player){
                // ... the player is in range.
                playerInRange = true;
            }
        }
    }
}