using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateLevel : MonoBehaviour
{
    private float speed= 0;

public GameObject Menu;

    // Start is called before the first frame update
    void Start()
    {                  Menu.gameObject.SetActive(false);
        
        StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update()
    { transform.Rotate(0,speed * Time.deltaTime , 0);
        
    }
    IEnumerator wait(){
        yield return new WaitForSeconds(2);
     
                Menu.gameObject.SetActive(true);

  speed = -10;
    }
}