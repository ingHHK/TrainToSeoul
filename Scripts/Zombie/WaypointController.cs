using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{

    public List<Transform> waypoints = new List<Transform>();
    private Transform targetWaypoint;
    EnemyHealth enemyHealth;
    private int targetWaypointIndex = 0;
    private float minDistance = 0.1f;
    private int lastWaypointIndex;

    private float movementSpeed = 5.0f;
    private float rotationSpeed = 2.0f;

    void Start(){
        lastWaypointIndex = waypoints.Count -1;
        targetWaypoint = waypoints[targetWaypointIndex];
        enemyHealth = GetComponent<EnemyHealth> ();
    }

    void Update(){  
        float movementStep = movementSpeed * Time.deltaTime;
        float rotationStep = rotationSpeed * Time.deltaTime;

        Vector3 directionToTarget = targetWaypoint.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);

        transform.rotation = rotationToTarget;

        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        CheckDistanceToWaypoint(distance);

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);

    }

    void CheckDistanceToWaypoint(float currentDistance){
        if(currentDistance <= minDistance){
            ++targetWaypointIndex;
            UpdateTargetWaypoint();
        }
    }

    void UpdateTargetWaypoint(){
        if(targetWaypointIndex > lastWaypointIndex){
            targetWaypointIndex = 0;
        }
        targetWaypoint = waypoints[targetWaypointIndex];
    }
}
