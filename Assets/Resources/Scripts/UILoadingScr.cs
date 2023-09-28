using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILoadingScr : MonoBehaviour
{
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    private void FixedUpdate() {
        count++;
    }

    private void Update() {
        if (count >= 50)
        {
            ScenesManager.Instance.LoadNextScene();
        }
    }
}
