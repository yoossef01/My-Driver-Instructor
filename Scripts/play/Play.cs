using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class Play : MonoBehaviour
{   public GameObject MenuPanel;

    private int score;
    private int level;
    public int panel;
    private FirebaseController F;
    public AudioMixer mainMixer;
    void Start(){
        score = scoreController.score;
        level=scoreController.level;
MenuPanel.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    public void PlayGame()
    {
        //SceneManager.LoadScene("level0 0");
        MenuPanel.gameObject.SetActive(true);
     
    }
    public void ContinueGame(){

  SceneManager.LoadScene("level0 "+level);
    }
    public void NewGame(){
        SceneManager.LoadScene("login");
      panel=2;
      scoreController.panel=panel;
    }
    public void LoadGame(){SceneManager.LoadScene("login"); panel=1;
      scoreController.panel=panel;

    } 
    public void Quit(){
      Application.Quit();
    }
    public void SetFullscreen (bool isFullscreen)
    {
      Screen.fullScreen=isFullscreen;


    }
    public void SetQuality(int qualityIndex){
      QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetVolume(float volume)
    {mainMixer.SetFloat("volume",volume);

    }
}
