using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizNuitLevel : MonoBehaviour
{
   private NodeControllerLevel NC;
public GameObject screen_1;
  private Animator playeranim;
  public GameObject lights;

    // Start is called before the first frame update
    void Start()
    {playeranim=lights.GetComponent<Animator>();

      NC = GameObject.Find("Player").GetComponent<NodeControllerLevel>();
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other){
        NC.movementSpeed =0;
        screen_1.gameObject.SetActive(true);
        playeranim.SetInteger("nuit",2);
        GameObject.Find("Main Camera").GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
        }
        
}