using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz_1Level : MonoBehaviour
{  private NodeControllerLevel NC;
public GameObject screen_1;

  
    // Start is called before the first frame update
    void Start()
    {

      NC = GameObject.Find("Player").GetComponent<NodeControllerLevel>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other){
        NC.movementSpeed =0;
        screen_1.gameObject.SetActive(true);
        
        }
        
}
