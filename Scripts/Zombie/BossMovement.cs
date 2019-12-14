using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class BossMovement : MonoBehaviour
    {
        Transform player;               // Reference to the player's position.
        PlayerHealth playerHealth;      // Reference to the player's health.
        EnemyHealth enemyHealth;        // Reference to this enemy's health.
        public Transform tr;
        private int speed = 7;


        void Awake()
        {
            // Set up the references.
            player = GameObject.FindGameObjectWithTag("Player").transform;
            playerHealth = player.GetComponent<PlayerHealth>();
            enemyHealth = GetComponent<EnemyHealth>();
        }

        void Update(){
            // If the enemy and the player have health left...
            if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0){
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                transform.LookAt(player);
            }
        }
    }
}