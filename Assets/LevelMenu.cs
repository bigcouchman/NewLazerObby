using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void OpenLevel(int id){
        string name = "Level " + id;
        SceneManager.LoadScene(name);
    }
}
