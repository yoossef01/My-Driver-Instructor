using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{   public int startTime =30;
   private Reponse_1 R;
    private Reponse_2 R2;
   private Reponse_3 R3;
   public Text Timere ;
   public bool begin = false ; 
    // Start is called before the first frame update
    void Start()
    { R2 = GameObject.Find("Button A").GetComponent<Reponse_2>();
       R = GameObject.Find("Button B").GetComponent<Reponse_1>();
                 R3 = GameObject.Find("Button C").GetComponent<Reponse_3>();
       Timere.text = "00:" + startTime.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {  
      if (begin == false  && startTime > 0 && R.clicked == false && R2.clicked == false && R3.clicked == false )
      {
          StartCoroutine(TimeTake());
      }
      if (startTime < 15){
          Timere.color = Color.red;
      }
      if(startTime == 0){
               
          startTime = 0;
      }
    }
    IEnumerator TimeTake(){
    begin = true ;
    yield return new WaitForSeconds(1);
    startTime -= 1;

    if(startTime < 10){
        Timere.text = "00:0" + startTime.ToString("0");
    }
    else 
    {
         Timere.text = "00:" + startTime.ToString("0");    }
   begin = false; }
    
}
