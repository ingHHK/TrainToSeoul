using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Instantiate : MonoBehaviour
{
    public GameObject Boss_zombie;
    public GameObject respawn_object;
    private GameController gameController;

    void Start(){
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    public void create(){
        Instantiate(Boss_zombie, respawn_object.transform.position, Quaternion.identity);
    }
}
