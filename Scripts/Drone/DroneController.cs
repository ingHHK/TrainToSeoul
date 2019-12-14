using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public Transform Players;

    private Transform start_point;
    private Transform end_point;
    Transform serum;

    private Vector3 PlayerPosition;
    private Vector3 targetPosition;
    Vector3 pos;
    private float delta = 0.2f;
    private float speed = 2.0f;
    private GameObject serumDetect;
    private GameObject ring;
    private GameController gameController;

    public bool isSerumDetected = false;

    void Start(){
        pos = transform.position;
        serumDetect = GameObject.Find("SerumDetect");
        ring = GameObject.Find("Ring");
        start_point = GameObject.FindGameObjectWithTag("StartPoint").GetComponent<Transform>();
        end_point = GameObject.FindGameObjectWithTag("EndPoint").GetComponent<Transform>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void Update(){
        if(isSerumDetected){
            DetectSerum();
        }
        else{
            if(gameController.timerCount % 2 == 0){
                DetectEndPoint();
            }
            else{
                DetectStartPoint();   
            }
        }
    }
    void OnTriggerEnter(Collider other){
        // If the entering collider is the player...
        if (other.gameObject.tag == "Serum"){
            // ... the player is in range.
            isSerumDetected = true;
            serum = other.gameObject.transform;
        }
    }
    
    void OnTriggerExit(Collider other){
        // If the entering collider is the player...
        if (other.gameObject.tag == "Serum"){
            // ... the player is in range.
            isSerumDetected = false;
        }
    }
    public void DetectSerum(){
        serumDetect.SetActive(true);
        ring.SetActive(false);
        transform.LookAt(serum);
    }

    public void DetectEndPoint(){
        Vector3 v = pos;

        PlayerPosition = new Vector3(Players.position.x, transform.position.y, Players.position.z);
        v.y += delta * Mathf.Sin(Time.time * speed);
        v.x = Players.position.x + 1;
        v.z = Players.position.z;
        transform.position = v;

        targetPosition = new Vector3(end_point.position.x, transform.position.y, end_point.position.z);
        ring.SetActive(true);
        serumDetect.SetActive(false);
        transform.LookAt(targetPosition);
    }

    public void DetectStartPoint(){
        Vector3 v = pos;

        PlayerPosition = new Vector3(Players.position.x, transform.position.y, Players.position.z);
        v.y += delta * Mathf.Sin(Time.time * speed);
        v.x = Players.position.x + 1;
        v.z = Players.position.z;
        transform.position = v;

        targetPosition = new Vector3(start_point.position.x, transform.position.y, start_point.position.z);
        ring.SetActive(true);
        serumDetect.SetActive(false);
        transform.LookAt(targetPosition);
    }
}
