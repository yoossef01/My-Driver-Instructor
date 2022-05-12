using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBarriere : MonoBehaviour
{ private Open O ;

  
    // Start is called before the first frame update
    void Start()
    {

      O = GameObject.Find("Parking Gate (1)").GetComponent<Open>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other){
       O.PlayerAnim.SetTrigger("Trigger");}
       
        
}
