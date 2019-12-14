using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CompleteProject
{
    public class Binoculars : MonoBehaviour
    {
        public GameObject BinoGetUI;
        GameObject player;
        PlayerShooting playerShooting;
        GameObject soundController;
        SoundController audio;
        bool playerInRange = false;
        // Start is called before the first frame update
        void Awake(){
            player = GameObject.FindGameObjectWithTag("Player");
            playerShooting = player.GetComponentInChildren<PlayerShooting>();
            soundController = GameObject.FindGameObjectWithTag("SoundController");
            audio = soundController.GetComponent<SoundController>();
        }

        // Update is called once per frame
        void Update(){
            transform.Rotate(new Vector3 (0 , 90, 0) * Time.deltaTime, Space.World);
            if(playerInRange){
                audio.Item();
                BinoGetUI.SetActive(true);
                StartCoroutine(DestroyUI(2));
                playerShooting.range += 5f;
                Destroy(gameObject, 0); 
            }
        }
        
        void OnTriggerEnter(Collider other){
            // If the entering collider is the player...
            if (other.gameObject == player){
                // ... the player is in range.
                playerInRange = true;
            }
        }
        
        IEnumerator DestroyUI(float delalyTime){                                   //안내메시지 ON/OFF
            yield return new WaitForSeconds(delalyTime);
            BinoGetUI.SetActive(false);
        }
    }
}