using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class CameraController : MonoBehaviour
{    public GameObject Player ;
   private Vector3 offset = new Vector3(-369.0f,73.6f,-9.5f);
public List<Transform> nodes = new List<Transform>();
    private Transform targetNode;
    private int targetNodeIndex = 0;
    private float minDistance = 0.1f; //If the distance between the enemy and the waypoint is less than this, then it has reacehd the waypoint
    private int lastNodeIndex;
     public GameObject TheDialoguescreen;
     public GameObject Skipped;
   IEnumerator myCoroutine;
    public float movementSpeed = 1.5f;
    public float rotationSpeed = 1.0f;
    private NodeController Nd ;
    int zoom = 30 ;
    int normal = 60;
    float smooth = 5;
    public bool zoomy = true;
   
	// Use this for initialization
	void Start () {
      
              Nd = GameObject.Find("Player").GetComponent<NodeController>();
       
     myCoroutine= Wait();
        StartCoroutine(myCoroutine);
        lastNodeIndex = nodes.Count - 1;
        targetNode = nodes[targetNodeIndex];
        // Skipped= GameObject.Find("Skip").GetComponent<Skip>(); //Set the first target waypoint at the start so the enemy starts moving towards a waypoint
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if(Nd.movementSpeed ==0 && zoomy == true) 
       { movementSpeed = Nd.movementSpeed;
       GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime*smooth);}
       else {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime*smooth);
           movementSpeed = 3.5f;
       }
        if(Nd.movementSpeed !=0 && zoomy == true&& targetNodeIndex==34) 
       { movementSpeed =3;
       GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime*smooth);} 
       if(Nd.movementSpeed ==0 && zoomy == false) 
       { movementSpeed =Nd.movementSpeed;
      // GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime*smooth);
      }
        if(zoomy == false && Nd.movementSpeed !=0)
       { movementSpeed = 2.6f;}
       if(zoomy == true && Nd.movementSpeed !=0 && targetNodeIndex>37){
           movementSpeed = 2.65f;
       }
        float movementStep = movementSpeed * Time.deltaTime;
        float rotationStep = rotationSpeed * Time.deltaTime;

        Vector3 directionToTarget = targetNode.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget); 

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep); 

       // Debug.DrawRay(transform.position, transform.forward * 50f, Color.green, 0f); //Draws a ray forward in the direction the enemy is facing
        //Debug.DrawRay(transform.position, directionToTarget, Color.red, 0f); //Draws a ray in the direction of the current target waypoint

        float distance = Vector3.Distance(transform.position, targetNode.position);
        CheckDistanceToNode(distance);

        transform.position = Vector3.MoveTowards(transform.position, targetNode.position, movementStep);
        if (targetNodeIndex == 0){
            zoomy = false;
        }
        if (targetNodeIndex == 1){
            zoomy = true;}
        if (targetNodeIndex == 16){
            zoomy = false;
        }
        if (targetNodeIndex == 17){
            zoomy = true;}
        if (targetNodeIndex == 18){
            zoomy = false;  }  
        if (targetNodeIndex == 35){
            zoomy = true;

        }
        if (targetNodeIndex == 36){
            zoomy = false;  }  
        if (targetNodeIndex == 37){
            zoomy = true;

        }
        if (Skipped.GetComponent<Skip>().skip==true){StopCoroutine(myCoroutine);
        TheDialoguescreen.gameObject.SetActive(false);}
        
        
       }  public void sky(){GetComponent<Camera>().clearFlags = CameraClearFlags.Skybox;}

        
	

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
    {    //set the bool to stop moving
        movementSpeed = 0;
        rotationSpeed =0;
         Debug.Log("Start to wait");

         yield return new WaitForSeconds(10);
 transform.position = offset;                transform.rotation = Quaternion.Euler(15,-100,0);

yield return new WaitForSeconds(49);
                    zoomy = false;

       transform.position= new Vector3(-381.5f,70.5f,-9);
       transform.rotation = Quaternion.Euler(0,90,0);
                yield return new WaitForSeconds(4);
                TheDialoguescreen.gameObject.SetActive(false);
                
                                yield return new WaitForSeconds(2);
zoomy = true;GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, 50, Time.deltaTime*smooth);
                transform.position= offset;
       transform.rotation = Quaternion.Euler(10,-90,0);

                       yield return new WaitForSeconds(2);
GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, 60, Time.deltaTime*smooth);
         movementSpeed = 3.5f;
      rotationSpeed = 1.5f;
       }
    
/* private void HandleZoom(){
     float zoomChangeAmount = 80f;
     if (Input.GetKey(KeyCode.A)){
         zoom -= zoomChangeAmount * Time.deltaTime;
     }
     if (Input.GetKey(KeyCode.Z)){
         zoom += zoomChangeAmount * Time.deltaTime ;
     }
 }
   */

    
}
