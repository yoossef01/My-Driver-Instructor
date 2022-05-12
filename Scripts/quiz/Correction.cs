using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Correction : MonoBehaviour
{    private Button but ;
   public Button B1;
    public Button B2;
     public Button B3;
   private Reponse_1 R1;
    private Reponse_2 R2;
   private Reponse_3 R3;
   public bool clicked=false; 
   private NodeController Nd;
   public Color ColorForFitAnswer1;
   public Color ColorForFitAnswer2;
   public static int level=1;
  
    // Start is called before the first frame update
    void Start()
    { scoreController.level=level; 
     
            
       R1 = GameObject.Find("Button B").GetComponent<Reponse_1>();
         R2 = GameObject.Find("Button A").GetComponent<Reponse_2>();        
            R3 = GameObject.Find("Button C").GetComponent<Reponse_3>();       

                  Nd = GameObject.Find("Player").GetComponent<NodeController>();


        but= GetComponent<Button>();
             

       but.onClick.AddListener(SetCorrection);
             

        
      //StartCoroutine(WaitReponse_2());
        
    }
    void SetCorrection(){
        if(clicked == false)
   { ColorBlock c = B1.colors;
        c.normalColor = ColorForFitAnswer1;
        c.highlightedColor = ColorForFitAnswer1;
        c.pressedColor = ColorForFitAnswer1;
        c.selectedColor = ColorForFitAnswer1;
        B1.colors = c ;
        ColorBlock c2 = B2.colors;
        c.normalColor = ColorForFitAnswer2;
        c.highlightedColor = ColorForFitAnswer2;
        c.pressedColor = ColorForFitAnswer2;
        c.selectedColor = ColorForFitAnswer2;
        B2.colors = c ;
        ColorBlock c3 = B3.colors;
        c.normalColor = ColorForFitAnswer1;
        c.highlightedColor = ColorForFitAnswer1;
        c.pressedColor = ColorForFitAnswer1;
        c.selectedColor = ColorForFitAnswer1;
        B3.colors = c ;
        if (R1.correct == true || R2.correct == true|| R3.correct == true ){
          Nd.UpdateScore(1);
          R1.correct = false;
        } 
       clicked = true ;
       R1.clicked = true ;R2.clicked = true ;R3.clicked = true ;
    }level=level+1;
    }
    void Update(){
      scoreController.level=level;
    }
   public void UpdateLevel(){
level=level+1;}
} 
        
