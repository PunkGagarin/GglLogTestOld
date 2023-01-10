using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.UI;

public class CoreLoginSystemV2 : MonoBehaviour {

    private bool isAuth;

    [SerializeField]
    private Button _loginWitchGoogleButton;


    public void Awake() {
        _loginWitchGoogleButton.onClick.AddListener(ManualAuth);
    }

    public void Start() {
        GoogleAuth();
    }

    private void Update() {
        if (PlayGamesPlatform.Instance.IsAuthenticated()) {
            Debug.Log("Google user name: + " + PlayGamesPlatform.Instance.GetUserDisplayName());
            Debug.Log("Google user id: + " + PlayGamesPlatform.Instance.GetUserId());
            Debug.Log("Google user local name: + " + PlayGamesPlatform.Instance.localUser.userName);
            Debug.Log("Google user local id: + " + PlayGamesPlatform.Instance.localUser.id);
            isAuth = true;
        }
    }

    private void GoogleAuth() {
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

    private void ManualAuth() {
        PlayGamesPlatform.Instance.ManuallyAuthenticate(ProcessAuthentication);
    }

    private void ProcessAuthentication(SignInStatus status) {
        if (status == SignInStatus.Success) {
            // Continue with Play Games Services
            Debug.Log("Auth is succeed!!!!!!!!!");
            Debug.Log("Google user name: + " + PlayGamesPlatform.Instance.GetUserDisplayName());
            Debug.Log("Google user id: + " + PlayGamesPlatform.Instance.GetUserId());
            Debug.Log("Google user local name: + " + PlayGamesPlatform.Instance.localUser.userName);
            Debug.Log("Google user local id: + " + PlayGamesPlatform.Instance.localUser.id);
            Debug.Log("Auth is succeed!!!!!!!!!");
        } else {
            Debug.Log("Auth status: " + status);
            _loginWitchGoogleButton.interactable = true;
        }
    }

}