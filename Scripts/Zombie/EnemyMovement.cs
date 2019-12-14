using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyMovement : MonoBehaviour
    {
        Transform player;               // Reference to the player's position.
        PlayerHealth playerHealth;      // Reference to the player's health.
        EnemyHealth enemyHealth;        // Reference to this enemy's health.
        UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.
        public Transform tr;
        private int speed = 2;

        void Awake (){
            // Set up the references.
            player = GameObject.FindGameObjectWithTag ("Player").transform;
            playerHealth = player.GetComponent <PlayerHealth> ();
            enemyHealth = GetComponent <EnemyHealth> ();
            nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
        }

        void Update (){
            // If the enemy and the player have health left...
            if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0){
                // ... set the destination of the nav mesh agent to the player.
                if(Vector3.Distance(player.transform.position, transform.position) > 10f) {
                    nav.enabled = true;
                    nav.SetDestination (tr.position);
                }
                
                else if(Vector3.Distance(player.transform.position, transform.position) <= 10f) {
                    nav.enabled = false;
                    transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                    transform.LookAt(player);
                }
            }

            else{
                // ... disable the nav mesh agent.
                nav.enabled = false;
            }
        }
    }
}