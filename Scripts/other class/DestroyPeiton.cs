using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPeiton : MonoBehaviour
{ public GameObject Object;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other){
        Destroy(Object);

    }
}
