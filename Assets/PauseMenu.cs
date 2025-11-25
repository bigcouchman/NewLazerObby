using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] MonoBehaviour playerMovement;
    
    public void Start(){
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (pauseMenu.activeSelf){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0;

        playerMovement.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Home(){
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }

    public void Resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1;

        playerMovement.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
