using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explain : MonoBehaviour
{private Button button ;
public GameObject Screen;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
      button.onClick.AddListener(SetExplain);
    }

    // Update is called once per frame
     void SetExplain(){
Screen.gameObject.SetActive(true);
         
    }
}
