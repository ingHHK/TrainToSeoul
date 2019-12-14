using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    private float horizontalMove;
    private float verticalMove;
    private float rotate;
    private Transform tr;

    public float moveSpeed = 6f;
    public float rotSpeed = 40f;

    PlayerSound audio;
    public Slider MouseSensitiveSlider;
    
    // Start is called before the first frame update
    void Start(){
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        audio = GetComponent<PlayerSound>();
    }

    // Update is called once per frame
    void Update(){
        horizontalMove = Input.GetAxisRaw ("Horizontal");
        verticalMove = Input.GetAxisRaw ("Vertical");
        rotate=Input.GetAxis("Mouse X");
        AnimationUpdate();
        // rotSpeed = MouseSensitiveSlider.value;
    }

    void FixedUpdate(){
        walk(horizontalMove, verticalMove);
        run();
    }

        void AnimationUpdate(){
        if(horizontalMove == 0 && verticalMove == 0){
            anim.SetBool("IsWalking", true);
            audio.setState(0);
        }

        else{
            anim.SetBool("IsWalking", false);
            audio.setState(1);
        }
    }

    public void MouseSetting(){
        rotSpeed = MouseSensitiveSlider.value;
    }

    void walk(float horizontalMove, float verticalMove) {
        anim.SetFloat("animSpeed", 0.9f);
        Vector3 moveDir = (Vector3.forward * verticalMove) + (Vector3.right * horizontalMove);
        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self);
        tr.Rotate(Vector3.up * rotSpeed * Time.deltaTime * rotate);
    }

    void run(){
        if(Input.GetKey (KeyCode.LeftShift)){
            audio.setState(2);
            moveSpeed = 12f;
            anim.SetFloat("animSpeed", 1.5f);
        }
        else
            moveSpeed = 6f;
    }
}
