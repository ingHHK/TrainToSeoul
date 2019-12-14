using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDroneController : MonoBehaviour
{
    public Transform Players;
    public Transform target;
    public Transform serum;
    private Transform startPoint;
    private Transform endPoint;

    private Vector3 PlayerPosition;
    private Vector3 targetPosition;
    private Vector3 SerumPosition;

    Vector3 pos;
    private float delta = 0.2f;
    private float speed = 2.0f;
    private GameObject serumDetect;
    private GameObject ring;

    public bool isSerumDetected = false;

    void Start(){
        pos = transform.position;
        serumDetect = GameObject.Find("SerumDetect");
        ring = GameObject.Find("Ring");
        SerumPosition = new Vector3(serum.position.x, serum.position.y, serum.position.z);
        startPoint = GameObject.FindGameObjectWithTag("StartPoint").GetComponent<Transform>();
        endPoint = GameObject.FindGameObjectWithTag("EndPoint").GetComponent<Transform>();
    }
    
    void Update(){
        if(isSerumDetected){
            DetectSerumPoint();
        }
        else{
            DetectEndPoint();
        }
    }
    
    void OnTriggerExit(Collider other){
        // If the entering collider is the player...
        if (other.gameObject.tag == "Serum"){
            // ... the player is in range.
            isSerumDetected = true;
        }
    }

    public void DetectSerumPoint(){
        ring.SetActive(false);
        serumDetect.SetActive(true);
        transform.LookAt(SerumPosition);
    }

    public void DetectEndPoint(){
        Vector3 v = pos;

        PlayerPosition = new Vector3(Players.position.x, transform.position.y, Players.position.z);
        v.y += delta * Mathf.Sin(Time.time * speed);
        v.x = Players.position.x + 1;
        v.z = Players.position.z;
        transform.position = v;

        targetPosition = new Vector3(endPoint.position.x, transform.position.y, endPoint.position.z);
        ring.SetActive(true);
        serumDetect.SetActive(false);
        transform.LookAt(targetPosition);
    }
}
