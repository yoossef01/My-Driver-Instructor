using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreUI : MonoBehaviour {
    [SerializeField] GameObject panel;
    [SerializeField] GameObject highscoreUIElementPrefab;
    [SerializeField] Transform elementWrapper;

    List<GameObject> uiElements = new List<GameObject> ();

    private void OnEnable () {
        HighscoreHandler.onHighscoreListChanged += UpdateUI;
    }

    private void OnDisable () {
        HighscoreHandler.onHighscoreListChanged -= UpdateUI;
    }

    public void ShowPanel () {
        panel.SetActive (true);
    }

    public void ClosePanel () {
        panel.SetActive (false);
    }

    private void UpdateUI (List<HighscoreElement> list) {
        for (int i = 0; i < list.Count; i++) {
          
            HighscoreElement el = list[i];
            if (el != null && el.points > 0) {
                if (i >= uiElements.Count ) {
                    // instantiate new entry
                    var inst = Instantiate (highscoreUIElementPrefab, Vector3.zero, Quaternion.identity);
                    inst.transform.SetParent (elementWrapper, false);

                    uiElements.Add (inst);
                }

                // write or overwrite name & points
                var texts = uiElements[i].GetComponentsInChildren<Text> ();
                texts[0].text = el.playerName;
                texts[1].text = el.points.ToString ();}}
             for (int i=0; i< uiElements.Count;i++){
                   for (int j=i+1; j< uiElements.Count;j++){
                var textsi = uiElements[i].GetComponentsInChildren<Text> ();
                 var textsj = uiElements[j].GetComponentsInChildren<Text> ();
               if (textsi[0].text == textsj[0].text && textsi[1].text == textsj[1].text)
                {
                    Destroy(uiElements[j]);
                    
                }
            } 
        }
            }
            
       
    

}
