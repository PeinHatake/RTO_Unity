using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILoginScr : MonoBehaviour
{
    [SerializeField] Button changeServer;
    [SerializeField] Button login;
    // Start is called before the first frame update
    void Start()
    {
        changeServer.onClick.AddListener(OnChangeServerButtonClick);
        login.onClick.AddListener(OnLoginButtonClick);
    }

    private void OnChangeServerButtonClick()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.ServerListScr);
    }
    private void OnLoginButtonClick()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.GameScr);
    }
}
