using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFade : MonoBehaviour
{    public Animator Transition ;
    public GameObject Robot ;
    public GameObject RobotSetted;
    public GameObject Skipped;
     IEnumerator myCoroutine;
    // Start is called before the first frame update
    void Start()
    {myCoroutine= LoadFade();
        StartCoroutine(myCoroutine);
        
    }

    // Update is called once per frame
    void Update()
    {if (Skipped.GetComponent<Skip>().skip==true){StopCoroutine(myCoroutine);
        }
        
    }



    IEnumerator LoadFade(){
        yield return new WaitForSeconds(58);
      Transition.SetTrigger("Fade"); 
              yield return new WaitForSeconds(2);
              Destroy(Robot);
              RobotSetted.gameObject.SetActive(true);




      yield return new WaitForSeconds(2);
      Transition.SetTrigger("Fade"); 
      

    }
}
