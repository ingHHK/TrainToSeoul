using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveUI : MonoBehaviour
{

    public GameObject HPUI;
    public GameObject SerumUI;
    public GameObject BinoUI;

    // Update is called once per frame
    void Update()
    {   
        if(BinoUI.activeSelf == true){
            StartCoroutine(DestroyBinoUI(2));
        }

        if(SerumUI.activeSelf == true){
            StartCoroutine(DestroySerumUI(2));
        }

        if(HPUI.activeSelf == true){
            StartCoroutine(DestroyHPUI(2));
        }
    }

    IEnumerator DestroyHPUI(float delalyTime){                                   //안내메시지 ON/OFF
        yield return new WaitForSeconds(delalyTime);
        HPUI.SetActive(false);
    }

    IEnumerator DestroySerumUI(float delalyTime){                                   //안내메시지 ON/OFF
        yield return new WaitForSeconds(delalyTime);
        SerumUI.SetActive(false);
    }

    IEnumerator DestroyBinoUI(float delalyTime){                                   //안내메시지 ON/OFF
        yield return new WaitForSeconds(delalyTime);
        BinoUI.SetActive(false);
    }
}
