using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveMesseage : MonoBehaviour
{

    public GameObject DayMesseage;
    public GameObject NightMesseage;

    public void GetDayOK(){
        Cursor.visible = false;                     //마우스 커서가 보이지 않게 함
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
        DayMesseage.SetActive(false);
    }

    public void GetNightOK(){
        Cursor.visible = false;                     //마우스 커서가 보이지 않게 함
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
        NightMesseage.SetActive(false);
    }
}
