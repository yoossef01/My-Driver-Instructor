using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttendreLevel : MonoBehaviour
{private NodeControllerLevel NC;
    // Start is called before the first frame update
    void Start()
    {
         NC = GameObject.Find("Player").GetComponent<NodeControllerLevel>();
    }

    // Update is called once per frame
   private void OnTriggerEnter(Collider other){
      
         NC.movementSpeed =3.4f;
     Debug.Log("marcher");
}}
