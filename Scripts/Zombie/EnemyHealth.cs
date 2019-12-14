using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 5;
    public int currentHealth;
    public float sinkSpeed = 0.1f;

    Animator anim;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    BoxCollider boxCollider;
    Zombie_Audio audio;
    
    private GameController gameController;
    bool isDead;
    bool isSinking;

    void Awake(){
        anim = GetComponent<Animator>();
        // enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        boxCollider = GetComponent<BoxCollider>();
        currentHealth = startingHealth;
        audio = GetComponent<Zombie_Audio>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void Update(){
        if (isSinking && anim.GetCurrentAnimatorStateInfo(0).IsName("Death") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int amount, Vector3 hitPoint){
        if (isDead)
            return;

        currentHealth -= amount;

        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if (currentHealth <= 0){   
            gameController.current_zombie -= 1;
            audio.setDie();
            Death();
            StartSinking();
        }
    }

    void Death(){
        isDead = true;

        capsuleCollider.isTrigger = true;

        capsuleCollider.enabled = false;

        boxCollider.enabled = false;

        anim.SetTrigger("Dead");
    }

    public void StartSinking(){
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        Destroy(gameObject, 2f);
    }
}