using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Instantiate : MonoBehaviour
{
    public GameObject zombie;
    public GameObject rush_zombie;
    public GameObject respawn_object;
    private GameController gameController;

    void Start(){
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    void Update(){

        if(gameController.zombie_count < 45){
            Instantiate(zombie, respawn_object.transform.position, Quaternion.identity);
            ++gameController.current_zombie;
            ++gameController.zombie_count;
        }

        if((gameController.timerCount != 1) && (gameController.rush_zombie_count < 12)){
            Instantiate(rush_zombie, respawn_object.transform.position, Quaternion.identity);
            ++gameController.current_zombie;
            ++gameController.rush_zombie_count;
        } 
    }
}
