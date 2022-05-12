using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    private NodeController NC;
    private Button button ;
    public GameObject Screen;
  private Reponse_1 R1;
    private Reponse_2 R2;
   private Reponse_3 R3;
  public GameObject C;
  
    // Start is called before the first frame update
    void Start()
    {button = GetComponent<Button>();
   // C = GameObject.Find("corrigé").GetComponent<Correction>();
    R1 = GameObject.Find("Button B").GetComponent<Reponse_1>();
         R2 = GameObject.Find("Button A").GetComponent<Reponse_2>();        
            R3 = GameObject.Find("Button C").GetComponent<Reponse_3>(); 
      NC = GameObject.Find("Player").GetComponent<NodeController>();
      
      button.onClick.AddListener(SetNext);
    }

    // Update is called once per frame
    void SetNext(){
          if(C.GetComponent<Correction>().clicked == true) 
         {
           NC.movementSpeed =3.4f;
         Screen.gameObject.SetActive(false);
          R1.clicked = false ;R2.clicked = false ;R3.clicked = false ;

         R2.GetComponent<Reponse_2>().enabled = true;
          R1.GetComponent<Reponse_1>().enabled = true;
          R3.GetComponent<Reponse_3>().enabled = true;}
          
        
    }
      
    
   
        
}
