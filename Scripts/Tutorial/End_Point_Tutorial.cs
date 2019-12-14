using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Point_Tutorial : MonoBehaviour
{
    GameObject player;
    public TutorialController gameController;
    bool playerInRange = false;

    int LevelNum;

    void Start(){
        LevelNum = SceneManager.GetActiveScene().buildIndex;
        player = GameObject.FindGameObjectWithTag ("Player");
        gameController = GetComponent<TutorialController>();
    }
    
    // Update is called once per frame
    void Update(){
        if(playerInRange){
            Debug.Log("Load Next Episode");
            LevelNum++;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(LevelNum);
        }
    }
    void OnTriggerEnter (Collider other){
        // If the entering collider is the player...
        if(other.gameObject.tag == "Player")
        {
        // ... the player is in range.
            playerInRange = true;
        }
    }
}
