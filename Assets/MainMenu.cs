using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlayGame(){
        SceneManager.LoadSceneAsync(2);
    }

    public void QuitGame(){
        // Debugging Quit Button
        //Debug.Log("Quitting Game");
        Application.Quit();
    }
}
