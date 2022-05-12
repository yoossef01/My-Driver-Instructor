using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using System;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using Firebase.Extensions;
using Firebase.Database; 
public class FirebaseController : MonoBehaviour
{public GameObject loginPanel,signupPanel,profilePanel,forgetPasswordPanel,notificationPanel,MenuPanel,image,image_1,background;
public Sprite imageback,imageback_2;
public InputField loginEmail,loginPassword,signupEmail,signupPassword,signupCPassword,signupUserName,forgetPasswordEmail;
 public Text notif_Title_Text,notif_Message_Text,profilUserName,profileEmail;
private InputHandler I;

   
Firebase.Auth.FirebaseAuth auth;
Firebase.Auth.FirebaseUser user;

bool isSignIn=false;
void Start(){if( scoreController.panel==2){OpenSignUpPanel();}
if( scoreController.panel==1){OpenLoginPanel();}
if( scoreController.panel==4){OpenMenuPanel();}
     Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
           var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                UnityEngine.Debug.LogError(
                  "Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
}

 public void OpenLoginPanel()
 {loginPanel.SetActive(true);
 signupPanel.SetActive(false);
 profilePanel.SetActive(false);
 forgetPasswordPanel.SetActive(false);MenuPanel.SetActive(false); 
 image.gameObject.SetActive(true);
 image_1.gameObject.SetActive(false);
  background.GetComponent<Image>().sprite = imageback_2;}
 public void OpenSignUpPanel(){
     loginPanel.SetActive(false);
     signupPanel.SetActive(true);
     profilePanel.SetActive(false);forgetPasswordPanel.SetActive(false);MenuPanel.SetActive(false); 
     image.gameObject.SetActive(true);
     image_1.gameObject.SetActive(false);
      background.GetComponent<Image>().sprite = imageback_2;
 }  
 public void OpenProfilePanel(){
     loginPanel.SetActive(false);
     signupPanel.SetActive(false);
     profilePanel.SetActive(true);forgetPasswordPanel.SetActive(false);
MenuPanel.SetActive(false); 
image_1.gameObject.SetActive(true);
image.gameObject.SetActive(false); background.GetComponent<Image>().sprite = imageback;
 }
 
    
 
  public void OpenMenuPanel(){
     loginPanel.SetActive(false);
     signupPanel.SetActive(false);
     profilePanel.SetActive(false);forgetPasswordPanel.SetActive(false);
   MenuPanel.SetActive(true);image_1.gameObject.SetActive(false);
   image.gameObject.SetActive(false); background.GetComponent<Image>().sprite = imageback_2;
   
     
 }
 public void OpenForgetPassPanel(){MenuPanel.SetActive(false); 
     loginPanel. SetActive(false);
     signupPanel.SetActive(false);
     profilePanel.SetActive(false);forgetPasswordPanel.SetActive(true);
     image.gameObject.SetActive(true);
     image_1.gameObject.SetActive(false);
 }
 public void LoginUser(){
     if(string.IsNullOrEmpty(loginEmail.text)&&string.IsNullOrEmpty(loginPassword.text))
     {showNotif("error","fields empty! please input details in all fields");
         return;
     }
     SignInUser(loginEmail.text,loginPassword.text);
     }
     public void SignUpUser()
     {
       if(string.IsNullOrEmpty(signupEmail.text)&&string.IsNullOrEmpty(signupPassword.text)&&string.IsNullOrEmpty(signupCPassword.text)&&string.IsNullOrEmpty(signupPassword.text) )
     {showNotif("error","fields empty! please input details in all fields");
         return;
     }
     createUser(signupEmail.text,signupPassword.text,signupUserName.text);
 }
 public void forgetPAss(){
     if(string.IsNullOrEmpty(forgetPasswordEmail.text))
     {showNotif("error","fields empty! please input details in all fields");
         return;}
         forgetPasswordSubmit(forgetPasswordEmail.text);
 }
 public void showNotif(string title, string message)
 {
     notif_Title_Text.text=""+title;
     notif_Message_Text.text=""+message;
     notificationPanel.SetActive(true);
 }
 public void CloseNotif(){
      notif_Title_Text.text="";
     notif_Message_Text.text="";
     notificationPanel.SetActive(false);
 }
 public void logout(){
 auth.SignOut();
 
 profilUserName.text="";
 SceneManager.LoadScene("Menu 2");
 //OpenLoginPanel();
 }
 void createUser(string email, string password,string Username)
 {
     auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {
  if (task.IsCanceled) {
    Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
    return;
  }
  if (task.IsFaulted) {
    Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
    foreach(Exception exception in task.Exception.Flatten().InnerExceptions)
    {
    Firebase.FirebaseException firebaseEx = exception as Firebase.FirebaseException;
    if (firebaseEx != null)
    {
        var errorCode = (AuthError)firebaseEx.ErrorCode;
        showNotif("Error", GetErrorMessage(errorCode));
    }}
    return;
  }

  // Firebase user has been created.
  Firebase.Auth.FirebaseUser newUser = task.Result;
  Debug.LogFormat("Firebase user created successfully: {0} ({1})",
      newUser.DisplayName, newUser.UserId);
          profileEmail.text=""+newUser.Email;
      profilUserName.text=""+newUser.DisplayName;
      UpdateUserProfile(Username);
      OpenProfilePanel();

});
 }
 public void SignInUser(string email,string password){
     auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {
  if (task.IsCanceled) {
    Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
    return;
  }
  if (task.IsFaulted) {
    Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
    foreach(Exception exception in task.Exception.Flatten().InnerExceptions)
    {
    Firebase.FirebaseException firebaseEx = exception as Firebase.FirebaseException;
    if (firebaseEx != null)
    {
        var errorCode = (AuthError)firebaseEx.ErrorCode;
        showNotif("Error", GetErrorMessage(errorCode));
    }}
    return;
  }

  Firebase.Auth.FirebaseUser newUser = task.Result;
  Debug.LogFormat("User signed in successfully: {0} ({1})",
      newUser.DisplayName, newUser.UserId);
      profileEmail.text=""+newUser.Email;
      profilUserName.text=""+newUser.DisplayName;
      OpenProfilePanel();
      
});
 }
 void InitializeFirebase() {
  auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
  auth.StateChanged += AuthStateChanged;
  AuthStateChanged(this, null);
   
}

void AuthStateChanged(object sender, System.EventArgs eventArgs) {
   if (auth.CurrentUser != user) {
    bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
    if (!signedIn && user != null) {
      Debug.Log("Signed out " + user.UserId);
    }
    user = auth.CurrentUser;
    if (signedIn) {
      Debug.Log("Signed in " + user.UserId);
      isSignIn=true;
    }
  }
}
void OnDestroy() {
  auth.StateChanged -= AuthStateChanged;
  auth = null;
}
void UpdateUserProfile(string UserName )
{
    Firebase.Auth.FirebaseUser user = auth.CurrentUser;
if (user != null) {
  Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile {
    DisplayName = UserName,
    PhotoUrl = new System.Uri("https://via.placeholder.com/150%20C/O%20https://placeholder.com/"),
  };
  user.UpdateUserProfileAsync(profile).ContinueWith(task => {
    if (task.IsCanceled) {
      Debug.LogError("UpdateUserProfileAsync was canceled.");
      return;
    }
    if (task.IsFaulted) {
      Debug.LogError("UpdateUserProfileAsync encountered an error: " + task.Exception);
      return;
    }

    Debug.Log("User profile updated successfully.");
    showNotif("Alert","Account Successfuly Created");
  });
}
}
bool isSigned=false;
void Update(){
  if(isSignIn){
    if(!isSigned)
    {isSigned=true;
    profileEmail.text=""+user.Email;
      profilUserName.text=""+user.DisplayName;
      isSigned=false;
      // OpenProfilePanel();
     
     
      }
  }
  
}

private static string GetErrorMessage(AuthError errorCode)
{
    var message = "";
    switch (errorCode)
    {
        case AuthError.AccountExistsWithDifferentCredentials:
            message = "Account Not Exist";
            break;
        case AuthError.MissingPassword:
            message = "Missing Password";
            break;
        case AuthError.WeakPassword:
            message = " password So weak";
            break;
        case AuthError.WrongPassword:
            message = " Wrong password ";
            break;
        case AuthError.EmailAlreadyInUse:
            message = "your Email Already in Use";
            break;
        case AuthError.InvalidEmail:
            message = "Your Email invalid";
            break;
        case AuthError.MissingEmail:
            message = "Your Email Missing";
            break;
        default:
            message = "Invalid error";
            break;
    }
    return message;
}
void forgetPasswordSubmit(string forgetPasswordEmail)
{
  auth.SendPasswordResetEmailAsync(forgetPasswordEmail).ContinueWithOnMainThread(task=>{
    if(task.IsCanceled){
      Debug.LogError("SendPasswordResetEmailAsync was canceled");
    }
    if(task.IsFaulted){
      foreach(Exception exception in task.Exception.Flatten().InnerExceptions)
    {
    Firebase.FirebaseException firebaseEx = exception as Firebase.FirebaseException;
    if (firebaseEx != null)
    {
        var errorCode = (AuthError)firebaseEx.ErrorCode;
        showNotif("Error", GetErrorMessage(errorCode));
    }
    } }
    showNotif("Alert","Successfully Send Email For Reset Password");
  }); 
}/*
 public void SaveDataButton()
    {StartCoroutine(UpdateUsernameAuth(usernameField.text));
        
        StartCoroutine(UpdateUsernameDatabase(usernameField.text));

        StartCoroutine(UpdateXp(int.Parse(xpField.text)));
        StartCoroutine(UpdateKills(int.Parse(killsField.text)));
        StartCoroutine(UpdateDeaths(int.Parse(deathsField.text)));
    }
        private IEnumerator UpdateUsernameAuth(string _username)
    {
        //Create a user profile and set the username
        UserProfile profile = new UserProfile { DisplayName = _username };

        //Call the Firebase auth update user profile function passing the profile with the username
        var ProfileTask = user.UpdateUserProfileAsync(profile);
        //Wait until the task completes
        yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

        if (ProfileTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
        }
        else
        {
            //Auth username is now updated
        }        
    }

private IEnumerator UpdateUsernameDatabase(string _username)
    {
        //Set the currently logged in user username in the database
        var DBTask = DBreference.Child("users").Child(user.UserId).Child("username").SetValueAsync(_username);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database username is now updated
        }
    }

    private IEnumerator UpdateXp(int _xp)
    {
        //Set the currently logged in user xp
        var DBTask = DBreference.Child("users").Child(user.UserId).Child("xp").SetValueAsync(_xp);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Xp is now updated
        }
    }

    private IEnumerator UpdateKills(int _kills)
    {
        //Set the currently logged in user kills
        var DBTask = DBreference.Child("users").Child(user.UserId).Child("kills").SetValueAsync(_kills);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Kills are now updated
        }
    }

    private IEnumerator UpdateDeaths(int _deaths)
    {
        //Set the currently logged in user deaths
        var DBTask = DBreference.Child("users").Child(user.UserId).Child("deaths").SetValueAsync(_deaths);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Deaths are now updated
        }
    }

    private IEnumerator LoadUserData()
    {
        //Get the currently logged in user data
        var DBTask = DBreference.Child("users").Child(user.UserId).GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else if (DBTask.Result.Value == null)
        {
            //No data exists yet
            xpField.text = "0";
            killsField.text = "0";
            deathsField.text = "0";
        }
        else
        {
            //Data has been retrieved
            DataSnapshot snapshot = DBTask.Result;

            xpField.text = snapshot.Child("xp").Value.ToString();
            killsField.text = snapshot.Child("kills").Value.ToString();
            deathsField.text = snapshot.Child("deaths").Value.ToString();
        }
    }*/
}
