using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piéton : MonoBehaviour
{
    public List<Transform> nodes = new List<Transform>();
    private Transform targetNode;
    private int targetNodeIndex = 0;
    private float minDistance = 0.1f; //If the distance between the enemy and the waypoint is less than this, then it has reacehd the waypoint
    private int lastNodeIndex;
  private Animator playeranim;
    public float movementSpeed = 3.0f;
    public float rotationSpeed = 1.0f;
private bool marcher=false;


    // Start is called before the first frame update
    void Start()
    { 
              
         lastNodeIndex = nodes.Count - 1;
        targetNode = nodes[targetNodeIndex]; //Set the first target waypoint at the start so the enemy starts moving towards a waypoint
	 playeranim=GetComponent<Animator>();
    }

    // Update is called once per frame
     void Update()
    {if( marcher == true){ 
     
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
    }
    }
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
    public void click(){
        marcher= true;
    }
  
          
}
