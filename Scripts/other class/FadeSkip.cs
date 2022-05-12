using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSkip : MonoBehaviour
{ public Animator Transition ;
    public GameObject Robot ;
    public GameObject RobotSetted;
    public GameObject Skipped;
     private NodeController Nd;
   private CameraController C;
  
    // Start is called before the first frame update
    void Start()
    {
        Nd = GameObject.Find("Player").GetComponent<NodeController>();

              C = GameObject.Find("Main Camera").GetComponent<CameraController>();
    }

    // Update is called once per frame
   

public void Set(){StartCoroutine(LoadFade());}

   IEnumerator LoadFade(){
       Debug.Log("apparaitre25");
     Transition.SetTrigger("Fade"); 
              yield return new WaitForSeconds(2);
              Destroy(Robot);
              RobotSetted.gameObject.SetActive(true);
        C.transform.position= new Vector3(-381.5f,70.5f,-9);
       C.transform.rotation = Quaternion.Euler(0,90,0);
      yield return new WaitForSeconds(2);
      Transition.SetTrigger("Fade"); 
      Debug.Log("apparaitre");
    yield return new WaitForSeconds(2);
         C.transform.position= new Vector3(-370,73.6f,-9.5f);
       C.transform.rotation = Quaternion.Euler(10,-90,0);
Nd.movementSpeed = 4.5f;
     Nd.rotationSpeed = 1.0f;
      C.movementSpeed = 3.5f;
      C.rotationSpeed = 1.5f;
    }
}