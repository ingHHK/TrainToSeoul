using UnityEngine;
using System.Collections;

public class BossHealth : MonoBehaviour
{
    public int startingHealth = 50;
    public int currentHealth;
    public float sinkSpeed = 0.1f;

    Animator anim;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    BoxCollider boxCollider;
    // Zombie_Audio audio;
    AudioSource audioSource;
    SoundController soundController;
    GameController gameController;
    BossController bossController;
    bool isDead;
    bool isSinking;

    void Awake(){
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        anim = GetComponent<Animator>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        currentHealth = startingHealth;
        audioSource = GetComponent<AudioSource>();
        bossController = GetComponent<BossController>();
        soundController = GameObject.FindGameObjectWithTag("SoundController").GetComponent<SoundController>();
    }

    void Update(){

        if (isSinking && anim.GetCurrentAnimatorStateInfo(0).IsName("Boss_Dead") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f){
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int amount, Vector3 hitPoint){

        if (bossController.isDead)
            return;

        currentHealth -= amount;

        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if (currentHealth <= 0){   
            gameController.current_zombie -= 1;
            soundController.boss_die();
            Death();
            StartSinking();
        }
    }

    void Death(){
        bossController.isDead = true;

        capsuleCollider.isTrigger = true;

        capsuleCollider.enabled = false;

        anim.SetTrigger("Dead");

    }

    public void StartSinking(){
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        Destroy(gameObject, 2f);
    }
}