using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialZomieNum : MonoBehaviour
{
    public GameObject zombie;
    public GameObject respawn_object;
    private GameObject gameController;
    private TutorialController script;

    void Start(){
        gameController = GameObject.FindWithTag("GameController");
        script = gameController.GetComponent<TutorialController>();
    }

    void Update(){
        if(script.zombie_count < 5){
            Instantiate(zombie, respawn_object.transform.position, Quaternion.identity);
            ++script.zombie_count;
        }
    }
}
