using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CompleteProject;
using UnityEngine.UI;

public class StartSceneController : MonoBehaviour
{
    public GameObject SettingUI;
    int index;
    // Start is called before the first frame update
    void Start(){
        index = SceneManager.GetActiveScene().buildIndex;
    }

    public void NewGame(){
        SceneManager.LoadScene(++index);
    }

    public void Continue(){
        //SceneManager.LoadScene(LoadNum);
    }

    public void Option(){
        SettingUI.SetActive(true);
    }

    public void Complete(){
        SettingUI.SetActive(false);
    }

    public void Exit(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
