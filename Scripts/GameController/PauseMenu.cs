using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject SettingMenuUI;

    BGMController bgm;
    CompleteProject.PlayerHealth playerHealth;
    private int curScene;

    private void Awake(){
        Cursor.visible = false;                     //마우스 커서가 보이지 않게 함
        Cursor.lockState = CursorLockMode.Locked;   //마우스 커서를 고정시킴
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<CompleteProject.PlayerHealth>();
        bgm = GameObject.FindGameObjectWithTag("BGMController").GetComponent<BGMController>();
        curScene = SceneManager.GetActiveScene().buildIndex;
        DontDestroyOnLoad(gameObject);
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (playerHealth.gameOver.activeSelf == true){
                playerHealth.gameOver.SetActive(false);
            }
            if (GameIsPaused){
                if (SettingMenuUI.activeSelf == true){
                    Pause();
                    SettingMenuUI.SetActive(false);
                }
                else{
                    Resume();
                }
            }
            else{
                Pause();
            }
        }
    }

    public void Resume(){
        bgm.resume();
        Cursor.visible = false;                     //마우스 커서가 보이지 않게 함
        Cursor.lockState = CursorLockMode.Locked;   //마우스 커서를 고정시킴
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Restart(){
        Resume();
        SceneManager.LoadScene(curScene);
    }

    void Pause(){   
        bgm.pause();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadSetting(){
        Debug.Log("Loading Menu... Please Wait...");
        pauseMenuUI.SetActive(false);
        SettingMenuUI.SetActive(true);
    }

    public void Complete(){
        Debug.Log("Complete...");
        SettingMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void QuitGame(){
        bgm.stop();
        Debug.Log("Quitting Game... Please Wait...");
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
    
    public void MainMenu(){
        Debug.Log("Main Menu...");
        SceneManager.LoadScene(0);
        Resume();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}