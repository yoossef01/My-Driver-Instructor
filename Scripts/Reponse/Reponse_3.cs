using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reponse_3 : MonoBehaviour
{
   
    private Button button ; 
   public GameObject Screen ;
   public Color ColorForAnswer;
   public Color ColorForFitAnswer;
   public bool clicked = false ;
   public bool correct = false;
  private Reponse_2 R2;
   private Reponse_1 R1;
   //public bool Next = false ;
    public GameObject C;
    
    // Start is called before the first frame update
    void Start()
    {  
    R1 = GameObject.Find("Button B").GetComponent<Reponse_1>();
         R2 = GameObject.Find("Button A").GetComponent<Reponse_2>();  
         button = GetComponent<Button>();
      button.onClick.AddListener(SetDifficulty);
      StartCoroutine(WaitReponse_2());
        
    }

    // Update is called once per frame
  
    void SetDifficulty(){
       
       if (clicked == false && R1.clicked == false && R2.clicked == false){ 
           clicked = true ;
          
           
           Debug.Log(gameObject.name + "are clicked");
        ColorBlock cb = button.colors;
        cb.normalColor = ColorForAnswer;
        cb.highlightedColor = ColorForAnswer;
        cb.pressedColor = ColorForAnswer;
        cb.selectedColor = ColorForAnswer;
        button.colors = cb ;  
         Screen.gameObject.SetActive(true);
        if (gameObject.CompareTag("correct")){correct = true;}
         
        
       }   
       
       
    }

  
     
      
    
    IEnumerator WaitReponse_2 () {
           while( clicked == false){
          yield return new WaitForSeconds(30);
        ColorBlock c = button.colors;
        c.normalColor = ColorForFitAnswer;
        c.highlightedColor = ColorForFitAnswer;
        c.pressedColor = ColorForFitAnswer;
        c.selectedColor = ColorForFitAnswer;
        button.colors = c ;
        Screen.gameObject.SetActive(true); 
        clicked = true ;
          C.GetComponent<Correction>().clicked = true ;  }
        
    }
    } 