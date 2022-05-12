using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopCarLevel : MonoBehaviour
{
    public GameObject Car;

  
    // Start is called before the first frame update
    void Start()
    {

    
    }

    // Update is called once per frame
    void Update()
    {
      
        
        
    }
    private void OnTriggerEnter(Collider other){
       
       Car.GetComponent<PathBusLevel>().marcher=false;
        }
   
}
