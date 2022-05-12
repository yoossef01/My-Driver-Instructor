using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ScreenCongrat : MonoBehaviour
{public GameObject screen;
public GameObject camera1;
public GameObject camera2;
//public TextMeshProUGUI congra;
    // Start is called before the first frame update
    void Start()
    {screen.gameObject.SetActive(false);
        StartCoroutine(wait());
    }
 void Awake(){
     //congra.text+= DemoScene.NodeController.points;
 }
    // Update is called once per frame
   
    IEnumerator wait(){
         yield return new WaitForSeconds(4);
         screen.gameObject.SetActive(true);
         yield return new WaitForSeconds(2);
         camera1.gameObject.SetActive(false);
         camera2.gameObject.SetActive(true);
    }
    public void Exit(){
      SceneManager.LoadScene("Menu 2");
    }
}
