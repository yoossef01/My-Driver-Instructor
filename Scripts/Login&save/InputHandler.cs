using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Audio;
public class InputHandler : MonoBehaviour {
    [SerializeField] InputField nameInput;
    [SerializeField] string filename;
    [SerializeField] Text Email;
    [SerializeField] Text Level;
    [SerializeField] Text Points;
     [SerializeField] Text Score;
    private int level;public AudioMixer mainMixer;
    private int points;
    private int score;
    List<InputEntry> entries = new List<InputEntry> ();
    public GameObject loadingScreen;
    public Slider slider;
    public Text Progress;

    private void Start () {
        entries = FileHandler.ReadListFromJSON<InputEntry> (filename);
       
    }
    void Update(){
         for (int i = 0; i < entries.Count; i++) {
           InputEntry el = entries[i];
           
           if (Email.text==""+el.playerName)
           {level=el.level;
           scoreController.level=levelload();
           scoreController.points=pointsload();
           scoreController.score=scoreload();
           scoreController.Email=Email.text;
           points=el.points;
           score=el.score;
        // levelLoaded=el.level;
          if(level == 31){
           Level.text=" Finished" ;
          }
          // scoreController.level=scoreController.levelLoaded;
          else{
           Level.text=""+el.level;}
           Points.text=""+el.points;
           Score.text=""+el.score;
           }
           }

               }
    int  levelload(){if (scoreController.level>level){return scoreController.level;}
    else {return level;}}
      int  scoreload(){if (scoreController.score>score){return scoreController.score;}
    else {return score;}}
     int  pointsload(){if (scoreController.points>points){return scoreController.points;}
    else {return points;}}
     public void AddLoadLevel(){
         entries.Add (new InputEntry (Email.text,levelload(),pointsload(),scoreload()) );
        FileHandler.SaveToJSON<InputEntry> (entries, filename);
        
     }           

    public void AddNameToList () {
        entries.Add (new InputEntry (nameInput.text, 0,0,0));
        nameInput.text = "";
        

        FileHandler.SaveToJSON<InputEntry> (entries, filename);
    }
    public void QuitGame(){
      SceneManager.LoadScene("Menu 2");
    }
    public void PlayGame()
    {
        if (scoreController.level!=31){
  StartCoroutine(LoadAsynchronously(0));}
  else{
    if (scoreController.points<24){
      SceneManager.LoadScene("lost");
    }
    else{
      SceneManager.LoadScene("succes");
    }
  }}
    public void ContinueGame(){
  if (scoreController.level!=31){
  StartCoroutine(LoadAsynchronously(level));}
  else if(scoreController.level==1){  StartCoroutine(LoadAsynchronously(0));}
  else {
    if (scoreController.points<24){
      SceneManager.LoadScene("lost");
    }
    else{
      SceneManager.LoadScene("succes");
    }
  }
    }
  IEnumerator LoadAsynchronously(int sceneIndex){
    AsyncOperation operation = SceneManager.LoadSceneAsync("level0 "+sceneIndex);
    loadingScreen.SetActive(true);
    while(!operation.isDone){
      float progress =Mathf.Clamp01(operation.progress / .9f);
      slider.value = progress;
      Progress.text = progress * 100f +"%";
      yield return null;
    }

  }
  public void SetVolume(float volume)
    {mainMixer.SetFloat("volume",volume);

    }
    
}