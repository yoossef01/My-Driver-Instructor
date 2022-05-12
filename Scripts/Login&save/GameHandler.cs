using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {
    
    [SerializeField] HighscoreHandler highscoreHandler;
    
    [SerializeField] string playerName;
void Start(){
    playerName=scoreController.Email;
    Debug.Log(playerName);
    
}
    
    public void SaveScore() {
        highscoreHandler.AddHighscoreIfPossible (new HighscoreElement (playerName, scoreController.score));
        
    }
}