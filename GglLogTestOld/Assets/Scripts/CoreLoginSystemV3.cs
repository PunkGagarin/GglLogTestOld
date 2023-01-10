using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;

public class CoreLoginSystemV3 : MonoBehaviour {

    public string Token;
    public string Error;

    private bool isAuth;

    public void Awake() {
        PlayGamesPlatform.Activate();
        LoginGooglePlayGames();
    }

    public void LoginGooglePlayGames() {
        PlayGamesPlatform.Instance.Authenticate((success) => {
            if (success == SignInStatus.Success) {
                Debug.Log("Login with Google Play games successful.");

                PlayGamesPlatform.Instance.RequestServerSideAccess(true, code => {
                    Debug.Log("Authorization code: " + code);
                    Token = code;
// This token serves as an example to be used for SignInWithGooglePlayGames
                });
            } else {
                Error = "Failed to retrieve Google play games authorization code";
                Debug.Log("Login Unsuccessful");
            }
        });
    }

    private void Update() {
        if (isAuth) return;

        if (PlayGamesPlatform.Instance.IsAuthenticated()) {
            Debug.Log("Google user name: + " + PlayGamesPlatform.Instance.GetUserDisplayName());
            Debug.Log("Google user id: + " + PlayGamesPlatform.Instance.GetUserId());
            Debug.Log("Google user local name: + " + PlayGamesPlatform.Instance.localUser.userName);
            Debug.Log("Google user local id: + " + PlayGamesPlatform.Instance.localUser.id);
            isAuth = true;
        }
    }

}