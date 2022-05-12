using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverLevel : MonoBehaviour
{private NodeControllerLevel NC;


  
    // Start is called before the first frame update
    void Start()
    {

      NC = GameObject.Find("Player").GetComponent<NodeControllerLevel>();

    }

    // Update is called once per frame
   private void OnTriggerEnter(Collider other){
        NC.movementSpeed =0;
        if (NC.points < 24)
          {SceneManager.LoadScene("lost");}
         else{SceneManager.LoadScene("succes");}

}}
