using UnityEngine;  
using UnityEngine.UI;  
using System.Collections;  
   
public class FadeInOut : MonoBehaviour{

    public float animTime = 5f;         // Fade 애니메이션 재생 시간 (단위:초).  
   
    public Text fadeText1;            // 택스트 오브젝트 가져오기
    public Text fadeText2;
    public Text fadeText3;
    public Text fadeText4;
   
    private float start_In = 1f;          // Mathf.Lerp 메소드 페이드인 첫번째 값.  
    private float end_In = 0f;            // Mathf.Lerp 메소드 페이드인 두번째 값.  
    private float time_In = 0f;           // Mathf.Lerp 메소드 페이드인 시간 값. 

    private float dealy = 0f;
    void Awake(){
    }  
   
    void Update(){  
        // StartCoroutine(fadeInAndOut(5, fadeText1));
        // StartCoroutine(fadeInAndOut(5, fadeText2));
        StartCoroutine(TextGenerator());
        
    }  
    
        // Fade-In 애니메이션 함수.  
    IEnumerator PlayFadeIn(Text text){  
        float start = 0f;
        float last = 0f;
        while(text.color.a!=1) {
            last += Time.deltaTime/5;
            text.color = new Color(1, 1, 1, Mathf.Lerp(start, last, 3f));
        }
        yield return new WaitForSeconds(5f);  
        yield return null;                                              
    }  

    IEnumerator PlayFadeOut(Text text){
        while(text.color.a!=0) {  
            text.color = new Color(1, 1, 1, Mathf.Lerp(1f, 0f, 20f));
        }
        yield return new WaitForSeconds(5f);
        yield return null;
    } 

    IEnumerator fadeInAndOut(Text text){               //fade-in 과 out 을 실행. delaytime만큼 텍스트를 띄움
        yield return StartCoroutine(PlayFadeIn(text));
        yield return StartCoroutine(PlayFadeOut(text));
        // yield return StartCoroutine(PlayFadeIn(text));
    }

    IEnumerator TextGenerator(){                                        //text들을 순차적으로 실행(코드 순서대로 실행됨)
        yield return StartCoroutine(fadeInAndOut(fadeText1));       
        yield return StartCoroutine(fadeInAndOut(fadeText2));
        yield return StartCoroutine(fadeInAndOut(fadeText3));
        yield return StartCoroutine(fadeInAndOut(fadeText4));
    }
}  