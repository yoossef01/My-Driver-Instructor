using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Close : MonoBehaviour
{
  private Button button ;
public GameObject Screen;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
      button.onClick.AddListener(SetClose);
    }

    // Update is called once per frame
     void SetClose(){
Screen.gameObject.SetActive(false);
         
    }
}
