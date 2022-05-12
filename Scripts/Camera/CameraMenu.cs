using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenu : MonoBehaviour
{   private float speed= 0;

public GameObject Menu;

    // Start is called before the first frame update
    void Start()
    {                  Menu.gameObject.SetActive(true);

        
    }

    // Update is called once per frame
    void Update()
    { speed = -10;
        transform.Rotate(0,speed * Time.deltaTime , 0);
        
    }}
    