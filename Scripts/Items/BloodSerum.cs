using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CompleteProject
{
    public class BloodSerum : MonoBehaviour
    {
        GameObject player;
        GameObject drone;
        GameObject soundController;
        SoundController audio;
        DroneController droneController;

        [SerializeField]
        SerumUI serumUI;
        public GameObject SerumGetUI;
        bool playerInRange = false;

        // Start is called before the first frame update
        void Awake(){
            player = GameObject.FindGameObjectWithTag("Player");
            serumUI = GameObject.FindGameObjectWithTag("SerumUI").GetComponent<SerumUI>();
            drone = GameObject.FindGameObjectWithTag("Drone");
            droneController = drone.GetComponent<DroneController>();
            soundController = GameObject.FindGameObjectWithTag("SoundController");
            audio = soundController.GetComponent<SoundController>();
        }

        
        // Update is called once per frame
        void Update(){

            transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime, Space.World);

            if (playerInRange)
            {
                audio.Serum();
                SerumGetUI.SetActive(true);
                GetSerum();
                droneController.isSerumDetected=false;
                droneController.DetectEndPoint();
                Destroy(gameObject);
            }
        }
        
        void OnTriggerEnter(Collider other){
            // If the entering collider is the player...
            if (other.gameObject == player){
                // ... the player is in range.
                playerInRange = true;
            }
        }

        void GetSerum(){
            serumUI.currentFill += 1;
        }
    }
}