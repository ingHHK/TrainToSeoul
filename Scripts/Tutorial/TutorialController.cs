using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    private float LimitTime = 30.0f;
    private float waitTime = 0;
    public int timerCount = 0;
    public int zombie_count = 0;
    public int rush_zombie_count = 0;
    public int RoundNum = 1;                                    //라운드 표시 변수

    public Text text_Timer;
    public GameObject light;
    public GameObject Create_Zombie;
    public GameObject serumUI;
    public CompleteProject.SerumUITutorial serum_count;
    public GameObject player;
    public CompleteProject.PlayerHealth hp;

    public GameObject DayTimeUI;
    public GameObject NightTimeUI;

    GameObject soundController;
    GameObject bgmController;
    SoundController audio;
    BGMController bgm;
    private float light_speed = 0.14f;

    GameObject serums;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        hp = player.GetComponent<CompleteProject.PlayerHealth>();
        serumUI = GameObject.FindGameObjectWithTag("SerumUI");
        serum_count = serumUI.GetComponent<CompleteProject.SerumUITutorial>();
        serums = GameObject.FindGameObjectWithTag("Serum");
        Create_Zombie.SetActive(false);
        soundController = GameObject.FindGameObjectWithTag("SoundController");
        audio = soundController.GetComponent<SoundController>();
        bgmController = GameObject.FindGameObjectWithTag("BGMController");
        bgm = bgmController.GetComponent<BGMController>();

        audio.StartAlarm();
        bgm.day();                                                //BGM출력
        DayTimeUI.SetActive(true);                                   //안내메시지 출력
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update(){
        //Round Transition
        if (LimitTime < 0){
            ++timerCount;

            if (timerCount % 2 == 0){
                light.transform.rotation = Quaternion.identity;
                light_speed = 0.14f;
                audio.Alarm();
                bgm.day();                                                                  //탐색 브금 켜기                           
                DayTimeUI.SetActive(true);                                                  //안내메시지 출력
                StartCoroutine(CallDayTimeUI(2));                                           //제거
                LimitTime = 30.0f;
                Create_Zombie.SetActive(false);
                zombie_count = 0;
            }
            else{
                light.transform.Rotate(Vector3.right, 45.0f);
                light_speed = 0.06f;
                audio.Alarm();
                bgm.night();                                                                //방어 브금 켜기
                NightTimeUI.SetActive(true);                                                //안내메시지 출력
                Time.timeScale = 0.0f;       
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;                     
                LimitTime = 30.0f;
                Create_Zombie.SetActive(true);
            }
        }

        if ((serums != null) && (timerCount == 0)){
            serums.transform.position = new Vector3(serums.transform.position.x, 1.5f, serums.transform.position.z);
        }

        LimitTime -= Time.deltaTime;
        text_Timer.text = "Time: " + Mathf.Round(LimitTime);
    }

    void FixedUpdate(){
        if (waitTime >= 0.01f){
            light.transform.Rotate(Vector3.right, light_speed);
            waitTime = 0;
        }
        waitTime += Time.deltaTime;
    }

    IEnumerator CallDayTimeUI(float delalyTime){     //안내메시지 ON/OF 
        Time.timeScale = 0f;                              
        yield return new WaitForSeconds(delalyTime);
        DayTimeUI.SetActive(false);
    }

    IEnumerator CallNightTimeUI(float delalyTime){                                  //안내메시지 ON/OFF
        yield return new WaitForSeconds(delalyTime);
        NightTimeUI.SetActive(false);
    }
}