using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CompleteProject;

public class End_Point : MonoBehaviour
{
    GameObject player;
    SerumUI serumUI;
    private GameController gameController;
    bool playerInRange = false;

    private int LevelNum;

    void Start(){
        LevelNum = SceneManager.GetActiveScene().buildIndex;
        player = GameObject.FindGameObjectWithTag ("Player");
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        serumUI = GameObject.FindGameObjectWithTag("SerumUI").GetComponent<SerumUI>();
    }
        // Update is called once per frame
    void Update(){
        if(playerInRange && (gameController.timerCount == 6) && (serumUI.currentFill == 3)){
            Debug.Log("Load Next Episode");
            LevelNum++;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(LevelNum);
        }
    }
    
    void OnTriggerEnter (Collider other){
        // If the entering collider is the player...
        if(other.gameObject.tag == "Player"){
        // ... the player is in range.
            playerInRange = true;
        }
    }
}
