using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NextNuitLevel : MonoBehaviour
{
   private NodeControllerLevel NC;
    private Button button ;
    public GameObject Screen;
  private Reponse_1 R1;
    private Reponse_2 R2;
   private Reponse_3 R3;
  public GameObject C;
  public GameObject lights;
  private Animator playeranim;
    // Start is called before the first frame update
    void Start()
    {button = GetComponent<Button>();

   // C = GameObject.Find("corrigé").GetComponent<Correction>();
    R1 = GameObject.Find("Button B").GetComponent<Reponse_1>();
         R2 = GameObject.Find("Button A").GetComponent<Reponse_2>();        
            R3 = GameObject.Find("Button C").GetComponent<Reponse_3>(); 
      NC = GameObject.Find("Player").GetComponent<NodeControllerLevel>();
      playeranim=lights.GetComponent<Animator>();
      button.onClick.AddListener(SetNext);
    }

    // Update is called once per frame
    void SetNext(){
          if(C.GetComponent<CorrectionLevel>().clicked == true) 
         {
           NC.movementSpeed =3.4f;
         Screen.gameObject.SetActive(false);
          R1.clicked = false ;R2.clicked = false ;R3.clicked = false ;

         R2.GetComponent<Reponse_2>().enabled = true;
          R1.GetComponent<Reponse_1>().enabled = true;
          R3.GetComponent<Reponse_3>().enabled = true;
          playeranim.SetInteger("nuit",1);}
          
        
    }
      
    
   
        
}
