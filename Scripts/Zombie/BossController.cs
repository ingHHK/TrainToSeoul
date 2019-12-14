using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    public enum CurrentState { idle, trace, attack, dead };
    public CurrentState currentState = CurrentState.idle;
    private Transform selfTr;
    private Transform playerTr;
    private NavMeshAgent nvAgent;
    private Animator animator;
    private SoundController soundController;
    public AudioSource audioSource;
    public AudioClip Boss_Idle;
    public AudioClip Zombie_Attack;
    public float traceDist = 20f;
    public float attackDist = 3f;
    public bool isDead = false;
    BossAttack bossAttack;

    // Start is called before the first frame update
    void Start(){
        selfTr = this.gameObject.GetComponent<Transform>();
        playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
        animator = this.gameObject.GetComponent<Animator>();
        soundController = GameObject.FindGameObjectWithTag("SoundController").GetComponent<SoundController>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
        bossAttack = this.gameObject.GetComponent<BossAttack>();
        nvAgent.destination = playerTr.position;

        StartCoroutine(this.CheckState());
        StartCoroutine(this.CheckStateForAction());
    }

    IEnumerator CheckState(){

        while (!isDead){
            yield return new WaitForSeconds(0.2f);
            float dist = Vector3.Distance(playerTr.position, selfTr.position);

            if (dist <= attackDist){
                currentState = CurrentState.attack;
                audioSource.clip = Zombie_Attack;
            }

            else if (dist <= traceDist){
                currentState = CurrentState.trace;
                audioSource.clip = Boss_Idle;
            }

            else{
                currentState = CurrentState.idle;
                audioSource.clip = null;
            }
        }
    }

    IEnumerator CheckStateForAction(){

        while (!isDead){

            switch (currentState){

                case CurrentState.idle:
                    bossAttack.playerInRange = false;
                    nvAgent.Stop();
                    animator.SetBool("isTrace", false);
                    break;

                case CurrentState.trace:
                    nvAgent.destination = playerTr.position;
                    nvAgent.Resume();
                    animator.SetBool("isTrace", true);
                    animator.SetBool("Attack", false);
                    break;

                case CurrentState.attack:
                    animator.SetBool("Attack", true);
                    break;
            }
            yield return null;
        }
    }
    // Update is called once per frame
    void Update(){
        StartCoroutine(this.CheckState());
        StartCoroutine(this.CheckStateForAction());
    }
}
