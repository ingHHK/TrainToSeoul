using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour, IPointerEnterHandler
{
    AudioSource reload;
    public bool mouseClicked = false;
    int index;

    // Start is called before the first frame update
    void Start(){
        reload = GetComponent<AudioSource>();
        index = SceneManager.GetActiveScene().buildIndex;
    }

    public void OnPointerEnter(PointerEventData eventData){
        Debug.Log("Reolad!!");
        reload.Play();
    }

    public void NextScene(){
        if(index < 11)
            SceneManager.LoadScene(++index);
        else
            SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void PrevScene(){
        SceneManager.LoadScene(--index);
        Time.timeScale = 1f;
    }
}
