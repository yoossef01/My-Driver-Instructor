using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro ;
public class RobotConroller : MonoBehaviour
{ public TextMeshProUGUI textDisplay;
    public string[] sentences ;
    private int index =0;
    private float typingSpeed = 0.1f;
    private bool next = false ;
    public GameObject TheDialoguescreen;
    public GameObject SkipDialogue;

    public List<Transform> nodes = new List<Transform>();
    private Transform targetNode;
    private int targetNodeIndex = 0;
    private float minDistance = 0.1f; //If the distance between the enemy and the waypoint is less than this, then it has reacehd the waypoint
    private int lastNodeIndex;
  private Animator playeranim;
    public float movementSpeed = 3.0f;
    public float rotationSpeed = 1.0f;
    private RobotInitial Rb  ;
    private bool Annimated= false;
    
	// Use this for initialization
	void Start () {         TheDialoguescreen.gameObject.SetActive(false);
        SkipDialogue.gameObject.SetActive(false);

 
        textDisplay.text="";
  StartCoroutine(Type2());
       // StartCoroutine(Type());
                      Rb = GameObject.Find("Stop").GetComponent<RobotInitial>();

        lastNodeIndex = nodes.Count - 1;
        targetNode = nodes[targetNodeIndex]; //Set the first target waypoint at the start so the enemy starts moving towards a waypoint
	 playeranim=GetComponent<Animator>();
     
    }
	// Update is called once per frame
	void Update () {
       
        float movementStep = movementSpeed * Time.deltaTime;
        float rotationStep = rotationSpeed * Time.deltaTime;
        playeranim.SetFloat("Speed_f",0.4f);

        Vector3 directionToTarget = targetNode.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget); 

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep); 

       // Debug.DrawRay(transform.position, transform.forward * 50f, Color.green, 0f); //Draws a ray forward in the direction the enemy is facing
        //Debug.DrawRay(transform.position, directionToTarget, Color.red, 0f); //Draws a ray in the direction of the current target waypoint

        float distance = Vector3.Distance(transform.position, targetNode.position);
        CheckDistanceToNode(distance);

        transform.position = Vector3.MoveTowards(transform.position, targetNode.position, movementStep);
       if (Rb.collised == true){
           movementSpeed = 0;
          // Debug.Log("salut");
                   playeranim.SetFloat("Speed_f",0.1f);
                   //playeranim.SetInteger("Animation_int",6);
                //playeranim.SetInteger("Animation_int",3);
          StartCoroutine(Wait());
          
        }
        if(next == true )
            {if(textDisplay.text == sentences[index])
            { NextDialogue();
            }
            else{
                StopAllCoroutines();
                textDisplay.text = sentences[index];            }
            }
        }




        public void NextDialogue(){
            
          if(index < sentences.Length - 1){
              index++;
              next = false;
            textDisplay.text = string.Empty; ;
        StartCoroutine(Type());
    }
    else {textDisplay.text=sentences[index];}

       }
        
    /// <summary>
    /// Checks to see if the enemy is within distance of the waypoint. If it is, it called the UpdateTargetWaypoint function 
    /// </summary>
    /// <param name="currentDistance">The enemys current distance from the waypoint</param>
    void CheckDistanceToNode(float currentDistance)
    {
        if(currentDistance <= minDistance)
        {
            targetNodeIndex++;
            UpdateTargetNode();
        }
    }
    /// <summary>
    /// Increaes the index of the target waypoint. If the enemy has reached the last waypoint in the waypoints list, it resets the targetWaypointIndex to the first waypoint in the list (causes the enemy to loop)
    /// </summary>
    void UpdateTargetNode()
    {
        if(targetNodeIndex > lastNodeIndex)
        {
            targetNodeIndex = 0;
        }

        targetNode = nodes[targetNodeIndex];
    }
    
  IEnumerator Wait()
    {   if( Annimated == false)   
         //set the bool to stop moving
       { playeranim.SetInteger("Animation_int",6);
         //Debug.Log("Start to wait");
        yield return new WaitForSeconds(3);}
        Annimated = true ;
        TheDialoguescreen.gameObject.SetActive(true);playeranim.SetInteger("Animation_int",100);
                yield return new WaitForSeconds(2);
      SkipDialogue.gameObject.SetActive(true);

        // playeranim.SetInteger("Animation_int",3);
               //  yield return new WaitForSeconds(3f);

         
                 yield return new WaitForSeconds(57);
                  yield return new WaitForSeconds(57);


                Rb.collised=false;


       }

    
    IEnumerator Type(){
        if ( next == false)
    {foreach(char letter in sentences[index].ToCharArray()){
        textDisplay.text += letter;
        yield return new WaitForSeconds(typingSpeed);  }
 yield return new WaitForSeconds(2);
   next =true;}
    
   
}

  IEnumerator Type2(){ yield return new WaitForSeconds(10);
  StartCoroutine(Type());}


    
}