using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CompleteProject;

public class GameController : MonoBehaviour
{
    private float LimitTime = 60.0f;
    private float waitTime = 0;
    public int timerCount = 0;
    public int zombie_count = 0;
    public int current_zombie = 0;
    public int rush_zombie_count = 0;
    public int RoundNum = 1;                                    //라운드 표시 변수

    public Text text_Timer;
    public Text RoundText;                                   //라운드표시 텍스트
    public Text ZombieNum;                                     //남은 좀비 표시 텍스트

    public GameObject serum1;
    public GameObject serum2;
    public GameObject serum3;

    public GameObject light;
    public GameObject Create_Zombie;
    GameObject serumUI;
    SerumUI serum_count;
    GameObject player;
    PlayerHealth hp;
    private GameObject playerLight;
    private Boss_Instantiate boss;

    public GameObject DayTimeUI;
    public GameObject NightTimeUI;

    GameObject soundController;
    GameObject bgmController;
    SoundController audio;
    BGMController bgm;
    private float light_speed = 0.07f;

    GameObject[] serums;

    void Awake(){
        boss = GameObject.FindGameObjectWithTag("CreateBoss").GetComponent<Boss_Instantiate>();
    }

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        hp = player.GetComponent<PlayerHealth>();
        playerLight = GameObject.FindGameObjectWithTag("PlayerLight");
        playerLight.SetActive(false);
        serumUI = GameObject.FindGameObjectWithTag("SerumUI");
        serum_count = serumUI.GetComponent<SerumUI>();
        serums = GameObject.FindGameObjectsWithTag("Serum");
        Create_Zombie.SetActive(false);
        soundController = GameObject.FindGameObjectWithTag("SoundController");
        audio = soundController.GetComponent<SoundController>();
        bgmController = GameObject.FindGameObjectWithTag("BGMController");
        bgm = bgmController.GetComponent<BGMController>();

        audio.Alarm();
        bgm.day();                                              //BGM출력
        DayTimeUI.SetActive(true);                              //안내메시지 출력
        RoundText.text = "Round  " + RoundNum;                  //라운드 표시
        StartCoroutine(CallDayTimeUI(2));                       //안내메시지 제거
    }

    void Update(){
        //Round Transition
        if (LimitTime < 0){
            ++timerCount;
            if (timerCount % 2 == 0){   
                playerLight.SetActive(false);
                light.transform.rotation = Quaternion.identity;
                light_speed = 0.06f;
                audio.Alarm();
                bgm.day();                                                                   //탐색 브금 켜기
                RoundText.text = "Round  " + RoundNum;                                      //라운드 표시
                DayTimeUI.SetActive(true);                                                  //안내메시지 출력
                StartCoroutine(CallDayTimeUI(2));                                           //제거
                LimitTime = 60.0f;
                Create_Zombie.SetActive(false);
                if(current_zombie != 0){ //현재 남아있는 좀비
                    hp.TakeDamage(hp.currentHealth);
                    Debug.Log("Dead because zombie is alive");
                }
                zombie_count = 0;
                rush_zombie_count = 0;
            }
            else{
                playerLight.SetActive(true);
                light.transform.Rotate(Vector3.right, 45.0f);
                light_speed = 0.03f;
                audio.Alarm();
                bgm.night();                                                      //방어 브금 켜기
                NightTimeUI.SetActive(true);                                                //안내메시지 출력
                StartCoroutine(CallNightTimeUI(2));                                         //제거
                RoundNum++;                                                                 //라운드 Num 증가시킴
                LimitTime = 90.0f;
                if (timerCount == 5)
                {
                    boss.create();
                    current_zombie += 1;
                }
                if (timerCount == 7)
                {
                    Debug.Log("Dead because round 4 is over");
                    hp.TakeDamage(hp.currentHealth);
                }
                Create_Zombie.SetActive(true);
            }
        }

        if ((serum1 != null) && (timerCount == 0)){
            serum1.transform.position = new Vector3(serum1.transform.position.x, 3.5f, serum1.transform.position.z);
        }
        else if ((serum2 != null) && (timerCount == 2)){
            serum2.transform.position = new Vector3(serum2.transform.position.x, 3.5f, serum2.transform.position.z);
        }
        else if ((serum3 != null) && (timerCount == 4)){
            serum3.transform.position = new Vector3(serum3.transform.position.x, 3.5f, serum3.transform.position.z);
        }

        LimitTime -= Time.deltaTime;
        text_Timer.text = "Time: " + Mathf.Round(LimitTime);
        ZombieNum.text = "zombies :  " + current_zombie;
    }

    void FixedUpdate(){
        if (waitTime >= 0.01f){
            light.transform.Rotate(Vector3.right, light_speed);
            waitTime = 0;
        }
        waitTime += Time.deltaTime;
    }

    IEnumerator CallDayTimeUI(float delalyTime){                                    //안내메시지 ON/OFF
        yield return new WaitForSeconds(delalyTime);
        DayTimeUI.SetActive(false);
    }

    IEnumerator CallNightTimeUI(float delalyTime){                                  //안내메시지 ON/OFF
        yield return new WaitForSeconds(delalyTime);
        NightTimeUI.SetActive(false);
    }
}