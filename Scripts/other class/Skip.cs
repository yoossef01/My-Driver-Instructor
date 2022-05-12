using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Skip : MonoBehaviour
{  private NodeController Nd;
   private CameraController C;
   private Button button ; 

   public bool skip=false;
    // Start is called before the first frame update
    void Start()
    {              Nd = GameObject.Find("Player").GetComponent<NodeController>();
              C = GameObject.Find("Main Camera").GetComponent<CameraController>();
 button = GetComponent<Button>();
        button.onClick.AddListener(SetVisible);
        
    }

    // Update is called once per frame
    void SetVisible()
    { 
      /* Nd.movementSpeed = 4.5f;
     Nd.rotationSpeed = 1.0f;
      C.movementSpeed = 3.5f;
      C.rotationSpeed = 1.5f;*/
    
    skip=true;}
}
