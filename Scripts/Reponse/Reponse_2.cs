using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reponse_2 : MonoBehaviour
{
    private Button button ; 
   public GameObject Screen ;
   public Color ColorForAnswer;
   public Color ColorForFitAnswer;
   public bool clicked = false ;
   public bool correct = false;
   private Reponse_1 R1;
   private Reponse_3 R3;
    public GameObject C;
   //public bool Next = false ;
   
   
    // Start is called before the first frame update
    void Start()
    { 
     
       R1 = GameObject.Find("Button B").GetComponent<Reponse_1>();
         R3 = GameObject.Find("Button C").GetComponent<Reponse_3>();  
         button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
      StartCoroutine(WaitReponse_2());
        
    }
  
    // Update is called once per frame
  
    void SetDifficulty(){
       
       if (clicked == false && R3.clicked == false && R1.clicked == false){ 
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
          C.GetComponent<Correction>().clicked = true ;}
        
    }
    } 