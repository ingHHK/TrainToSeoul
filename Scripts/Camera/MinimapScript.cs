using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapScript : MonoBehaviour
{
    Transform player;
    // Start is called before the first frame update
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate(){
        transform.position = new Vector3(player.position.x, 0, player.position.z);
    }
}
