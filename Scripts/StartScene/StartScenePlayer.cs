using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScenePlayer : MonoBehaviour
{
    Animator anim;
    private float horizontalMove;
    private float verticalMove;
    private float rotate;
    private Transform tr;
    public float moveSpeed = 6f;
    public float rotSpeed = 80f;

    // Start is called before the first frame update
    void Start(){
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        horizontalMove = Input.GetAxisRaw ("Horizontal");
        verticalMove = Input.GetAxisRaw ("Vertical");
        rotate=Input.GetAxis("Mouse X");
        AnimationUpdate();
    }

    void AnimationUpdate(){
        if(horizontalMove == 0 && verticalMove == 0){
            anim.SetBool("IsWalking", true);
        }
        else{
            anim.SetBool("IsWalking", false);
        }
    }
}
