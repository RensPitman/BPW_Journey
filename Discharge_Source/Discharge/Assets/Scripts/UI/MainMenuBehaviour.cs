using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{
    private void Update()
    {
        if(Input.anyKey)
        {
            SceneManager.LoadScene(1);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
