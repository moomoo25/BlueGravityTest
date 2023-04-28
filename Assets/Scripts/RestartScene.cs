using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartScene : MonoBehaviour
{

    bool isLoad = false;
    void Update()
    {
        if (isLoad)
            return;

        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            isLoad = true;
        }
    }
}
