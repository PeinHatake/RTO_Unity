using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIServerListScr : MonoBehaviour
{
    [SerializeField] Button[] serverName;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < serverName.Length; i++)
        {
            serverName[i].onClick.AddListener(OnServerButtonClick);
        }
    }

    private void OnServerButtonClick()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.LoginScr);
    }
}
