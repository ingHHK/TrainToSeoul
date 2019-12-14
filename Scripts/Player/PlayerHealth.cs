using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

namespace CompleteProject
{
    public class PlayerHealth : MonoBehaviour
    {
        public enum CurrentHP { HP0, HP1, HP2, HP3, HP4, HP5, HP6, HP7, HP8, HP9, HP10 };
        public CurrentHP currentHP = CurrentHP.HP10;
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
            anim = GetComponent<Animator>();
            playerController = GetComponent<PlayerController>();
            playerShooting = GetComponentInChildren<PlayerShooting>();
            soundController = GameObject.FindGameObjectWithTag("SoundController");
            audio = soundController.GetComponent<SoundController>();

            // Set the initial health of the player.
            numOfHearts = startingHealth / 2;
            currentHealth = startingHealth;
            for(int i = 0; i < startingHealth / 2; i++){
                if (i < numOfHearts){
                    hearts[i].enabled = true;
                }
                else{
                    hearts[i].enabled = false;
                }
            }
        }

        void Update(){
            StartCoroutine(CheckHP());
            StartCoroutine(CheckHPForAction());
        }


        public void TakeDamage(int amount){

            // Reduce the current health by the damage amount.
            currentHealth -= amount;
            StartCoroutine(ShowBloodScreen());
            // Set the health bar's value to the current health.
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

        IEnumerator CheckHP(){
            while (!isDead){
                yield return new WaitForSeconds(0.2f);

                switch (currentHealth){
                    case 10:
                        currentHP = CurrentHP.HP10;
                        break;
                    case 9:
                        currentHP = CurrentHP.HP9;
                        break;
                    case 8:
                        currentHP = CurrentHP.HP8;
                        break;
                    case 7:
                        currentHP = CurrentHP.HP7;
                        break;
                    case 6:
                        currentHP = CurrentHP.HP6;
                        break;
                    case 5:
                        currentHP = CurrentHP.HP5;
                        break;
                    case 4:
                        currentHP = CurrentHP.HP4;
                        break;
                    case 3:
                        currentHP = CurrentHP.HP3;
                        break;
                    case 2:
                        currentHP = CurrentHP.HP2;
                        break;
                    case 1:
                        currentHP = CurrentHP.HP1;
                        break;
                    case 0:
                        currentHP = CurrentHP.HP0;
                        break;
                }
                yield return null;
            }
        }

        IEnumerator CheckHPForAction(){
            while (!isDead){
                switch (currentHP){
                    case CurrentHP.HP10:
                        for(int i = 0; i < 5; ++i){
                            hearts[i].sprite = fullHeart;
                        }
                        break;

                    case CurrentHP.HP9:
                        for(int i = 0; i < 4; ++i){
                            hearts[i].sprite = fullHeart;
                        }
                        hearts[4].sprite = halfHeart;
                        break;

                    case CurrentHP.HP8:
                        for(int i = 0; i < 4; ++i){
                            hearts[i].sprite = fullHeart;
                        }
                        hearts[4].sprite = emptyHeart;
                        break;

                    case CurrentHP.HP7:
                        for(int i = 0; i < 3; ++i){
                            hearts[i].sprite = fullHeart;
                        }
                        hearts[3].sprite = halfHeart;
                        hearts[4].sprite = emptyHeart;
                        break;

                    case CurrentHP.HP6:
                        for(int i = 0; i < 3; ++i){
                            hearts[i].sprite = fullHeart;
                        }
                        for (int i = 3; i <= 4; ++i){
                            hearts[i].sprite = emptyHeart;
                        }
                        break;

                    case CurrentHP.HP5:
                        for (int i = 0; i < 2; ++i){
                            hearts[i].sprite = fullHeart;
                        }
                        hearts[2].sprite = halfHeart;
                        for (int i = 3; i < 5; ++i){
                            hearts[i].sprite = emptyHeart;
                        }
                        break;

                    case CurrentHP.HP4:
                        for (int i = 0; i < 2; ++i){
                            hearts[i].sprite = fullHeart;
                        }
                        for (int i = 2; i < 5; ++i){
                            hearts[i].sprite = emptyHeart;
                        }
                        break;

                    case CurrentHP.HP3:
                        for (int i = 0; i < 1; ++i){
                            hearts[i].sprite = fullHeart;
                        }
                        hearts[1].sprite = halfHeart;
                        for (int i = 2; i < 5; ++i){
                            hearts[i].sprite = emptyHeart;
                        }
                        break;

                    case CurrentHP.HP2:
                        for (int i = 0; i < 1; ++i){
                            hearts[i].sprite = fullHeart;
                        }
                        for (int i = 1; i < 5; ++i){
                            hearts[i].sprite = emptyHeart;
                        }
                        break;

                    case CurrentHP.HP1:
                        hearts[0].sprite = halfHeart;
                        for (int i = 1; i < 5; ++i){
                            hearts[i].sprite = emptyHeart;
                        }
                        break;

                    case CurrentHP.HP0:
                        for (int i = 0; i < 5; ++i){
                            hearts[i].sprite = emptyHeart;
                        }
                        isDead = true;
                        break;
                }
                yield return null;
            }
        }
    }
}