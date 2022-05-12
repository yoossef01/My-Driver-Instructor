using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attendre : MonoBehaviour
{private NodeController NC;
    // Start is called before the first frame update
    void Start()
    {
         NC = GameObject.Find("Player").GetComponent<NodeController>();
    }

    // Update is called once per frame
   private void OnTriggerEnter(Collider other){
      
         NC.movementSpeed =3.4f;
     Debug.Log("marcher");
}}
