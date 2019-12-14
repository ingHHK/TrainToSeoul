using UnityEngine;
using System.Collections;
using CompleteProject;
public class BossAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 1.2f;     // The time in seconds between each attack.
    public int attackDamage = 2;               // The amount of health taken away per attack.

    // Zombie_Audio audio;
    Animator anim;                              // Reference to the animator component.
    GameObject player;                          // Reference to the player GameObject.
    PlayerHealth playerHealth;                  // Reference to the player's health.
    BossHealth bossHealth;                    // Reference to this enemy's health.
    BossController bossController;
    public bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer;                                // Timer for counting up to the next attack.
    float wait;

    void Awake(){
        // Setting up the references.
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        bossHealth = GetComponent<BossHealth>();
        anim = GetComponent<Animator>();
        bossController = GetComponent<BossController>();
    }

    void Update(){
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;
        wait += Time.deltaTime;

        if(wait >= 3f){
            bossController.audioSource.volume = 0.4f;
            bossController.audioSource.Play();
            wait = 0f;
        }

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks && playerInRange && bossHealth.currentHealth > 0){
            // ... attack.
            bossController.audioSource.volume=0.6f;
            bossController.audioSource.Play();
            Attack();
        }

        // If the player has zero or less health...
        if (playerHealth.currentHealth <= 0){
            // ... tell the animator the player is dead.
            anim.SetTrigger("PlayerDead");
        }
    }

    void Attack(){
        // Reset the timer.
        timer = 0f;

        // If the player has health to lose...
        if (playerHealth.currentHealth > 0){
            // ... damage the player.

            playerHealth.TakeDamage(attackDamage);
        }
    }

    void OnTriggerEnter(Collider other){
        // If the entering collider is the player...
        if (other.gameObject == player){
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other){
        // If the exiting collider is the player...
        if (other.gameObject == player){
            playerInRange = false;
        }
    }
}