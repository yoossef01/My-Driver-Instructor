using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using System.Threading.Tasks;
//using Firebase.Unity.Editor;
using UnityEngine.UI;
public class DataBase : MonoBehaviour
{ DatabaseReference reference;
public InputField email;
public Text  showText;
    // Start is called before the first frame update
    void Start()
    {     
   
        reference = FirebaseDatabase.DefaultInstance.RootReference;

    }

    // Update is called once per frame
    public void SaveData(){
    reference.Child("Users").Child("user 1").Child("Email").SetValueAsync(email.text.ToString()).ContinueWith(task => {
  if (task.IsCompleted){
      Debug.Log("sucess");}
 else{Debug.Log("errrrrr");}
  });
    }
    public void loadData(){
          FirebaseDatabase.DefaultInstance.GetReference("Users").ValueChanged+=Script_ValueChanged; 
    void Script_ValueChanged(object sender , ValueChangedEventArgs e){
        showText.text = e.Snapshot.Child("User1").Child("Email").GetValue(true).ToString();
    }
    }
}
