using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class EemnyRushMovement : MonoBehaviour
{
        UnityEngine.AI.NavMeshAgent nav;              
        public Transform tr;
        EnemyHealth enemyHealth;

        void Awake (){
            nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
            enemyHealth = GetComponent <EnemyHealth> ();
        }


        void Update (){
            if(enemyHealth.currentHealth > 0){
                nav.SetDestination (tr.position);
            }

            else{
                nav.enabled = false;
            }
        }
}
