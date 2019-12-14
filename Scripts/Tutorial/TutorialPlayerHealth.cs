using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

namespace CompleteProject
{
    public class TutotialPlayerHealth : MonoBehaviour
    {
        public int startingHealth = 10;                            // The amount of health the player starts the game with.
        public int currentHealth;                                   // The current health the player has.
        public Image[] hearts;                                 // Reference to the UI's health bar.
        int numOfHearts;
        public Sprite fullHeart;
        public Sprite halfHeart;
        public Sprite emptyHeart;

        public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
        public AudioClip deathClip;                                 // The audio clip to play when the player dies.

        Animator anim;                                              // Reference to the Animator component.
        PlayerController playerController;                              // Reference to the player's movement.
        PlayerShooting playerShooting;                              // Reference to the PlayerShooting script.
        bool isDead;                                                // Whether the player is dead.
        GameObject soundController;
        SoundController audio;

        public GameObject gameOver;

        void Awake(){
            // Setting up the references.
            anim = GetComponent<Animator>();
            playerController = GetComponent<PlayerController>();
            playerShooting = GetComponentInChildren<PlayerShooting>();
            soundController = GameObject.FindGameObjectWithTag("SoundController");
            audio = soundController.GetComponent<SoundController>();

            // Set the initial health of the player.
            numOfHearts = startingHealth / 2;
            currentHealth = startingHealth;
            for (int i = 0; i < startingHealth / 2; i++){
                if (i < numOfHearts){
                    hearts[i].enabled = true;
                }
                else{
                    hearts[i].enabled = false;
                }
            }
        }

        void Update(){
            if (currentHealth >= 10){
                currentHealth = 10;
            }

            if (currentHealth % 2 == 1){
                for (int i = 0; i < (currentHealth) / 2; i++){
                    hearts[i].sprite = fullHeart;
                }
                hearts[currentHealth / 2].sprite = halfHeart;
            }
            else{
                for (int i = 4; i > (currentHealth - 2) / 2; i--){
                    hearts[i].sprite = emptyHeart;
                }
                for (int i = 0; i < (currentHealth / 2); i++)
                    hearts[i].sprite = fullHeart;
            }
        }

        public void TakeDamage(int amount){

            // Reduce the current health by the damage amount.
            currentHealth -= amount;
            StartCoroutine(ShowBloodScreen());
            // Set the health bar's value to the current health.
            //healthSlider.value = currentHealth;

            // If the player has lost all it's health and the death flag hasn't been set yet...
            if (currentHealth <= 0 && !isDead){
                // ... it should die.
                Death();
                gameOver.SetActive(true);
            }
        }


        void Death(){
            audio.player_die();
            // Set the death flag so this function won't be called again.
            isDead = true;

            // Turn off any remaining shooting effects.
            playerShooting.DisableEffects();

            // Tell the animator that the player is dead.
            anim.SetTrigger("Die");

            // Turn off the movement and shooting scripts.
            playerController.enabled = false;
            playerShooting.enabled = false;
        }

        public void RestartLevel(){
            // Reload the level that is currently loaded.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        IEnumerator ShowBloodScreen(){
            damageImage.color = new Color(1, 1, 1, UnityEngine.Random.Range(0.2f, 0.3f));
            yield return new WaitForSeconds(0.3f);
            damageImage.color = Color.clear;
        }
    }
}