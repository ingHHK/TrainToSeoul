using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private int pos = 0;
    private float time = 0.0f;

    void Update(){
        time += Time.deltaTime;
        if(time >= 1){
            ++pos;
            if(pos > 3){
                pos = -3;
            }
            transform.Translate(pos, 0, 0);
            time = 0;
        }
    }
}
