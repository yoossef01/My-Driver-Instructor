using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotInitial : MonoBehaviour
{  
public bool collised ;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnTriggerEnter(Collider other){
        //Rb.movementSpeed = 0;
       // Rb.rotationSpeed = 0;
       // Debug.Log("hello");
        collised = true ;
        //Rb.playeranim.SetFloat("Speed_f",0.1f);
        //Rb.playeranim.SetTrigger("Stop");
       }
}
