using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro ;
using UnityEngine.SceneManagement;using UnityEngine.Audio;

public class NodeControllerLevel : MonoBehaviour {

    public List<Transform> nodes = new List<Transform>();
    private Transform targetNode;
    private int targetNodeIndex = 0;
    private float minDistance = 0.1f; //If the distance between the enemy and the waypoint is less than this, then it has reacehd the waypoint
    private int lastNodeIndex;
    public int points ,score ;
    
    public int panel;
    public TextMeshProUGUI scoreText;
    public float movementSpeed = 4.0f;
    public float rotationSpeed = 1.0f;
   IEnumerator myCoroutine;
   private NodeController N;
   public GameObject pauseMenuUI;
   public List<Timer> Timer = new List<Timer>();
   private int timer; public AudioMixer mainMixer;
	// Use this for initialization
	void Start () {
        points = scoreController.points;
       score = scoreController.score;
          scoreText.text = "Points : " + points+" /30"+"\r\n" +"Score : "+score;
        myCoroutine=Wait();
        StartCoroutine(myCoroutine);
        lastNodeIndex = nodes.Count - 1;
        targetNode = nodes[targetNodeIndex];   // Skipped= GameObject.Find("Skip").GetComponent<Skip>();//Set the first target waypoint at the start so the enemy starts moving towards a waypoint
	}

	// Update is called once per frame
	void Update () {

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
        scoreController.points=points;
        scoreController.score=score;

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
    {    //set the bool to stop moving
        movementSpeed = 0;
        rotationSpeed =0;
         
        scoreText.text = "";
                yield return new WaitForSeconds(2);
         movementSpeed = 4.5f;
      rotationSpeed = 1.0f;
             // scoreText.text = "Score : " + points;
scoreText.text = "Points : " + points+" /30"+"\r\n" +"Score : "+score;
       }

    public void UpdateScore(int scoreToAdd){
       points += scoreToAdd;
        
       timer=  (Timer[scoreController.level-1].startTime)*100;
        score =scoreController.score +timer;
       scoreText.text = "Points : " + points+" /30"+"\r\n" +"Score : "+score;
        
    }

public void QuitGame(){
    SceneManager.LoadScene("Login");panel=4;
   scoreController.panel=panel;
   Debug.Log(""+scoreController.level);
   Time.timeScale=1f;
} 
public void Resume(){
pauseMenuUI.SetActive(false);
Time.timeScale = 1f;AudioListener.pause=false;

}
public void Pause(){
pauseMenuUI.SetActive(true);
Time.timeScale = 0f;AudioListener.pause=true;
}
public void SetVolume(float volume)
    {mainMixer.SetFloat("volume",volume);

    }
}