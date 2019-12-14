using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CompleteProject
{
public class SerumUI : MonoBehaviour
{
        BloodSerum bloodSerum;
        GameObject serum;
        public GameObject Count;
        float amount;
        private Image fill;
        public float currentFill = 0;
        private float MaxFill=3;

    // Start is called before the first frame update
    void Start(){
        serum = GameObject.FindGameObjectWithTag ("Serum");
        bloodSerum = serum.GetComponent<BloodSerum>();
        fill = GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update(){   
        amount = currentFill / MaxFill;
        fill.fillAmount = Mathf.Lerp(fill.fillAmount, amount, Time.deltaTime * 2f);
        Count.GetComponent<Text>().text = currentFill.ToString() + " / 3";
    }
}
}
