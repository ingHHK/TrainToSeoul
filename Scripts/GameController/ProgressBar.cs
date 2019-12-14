using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider progress_bar;
    private float waitTime = 0;

    void Update(){
        if (waitTime > 1.0f){
            ++progress_bar.value;
            waitTime = 0;
        }
        waitTime += Time.deltaTime;
    }
}
