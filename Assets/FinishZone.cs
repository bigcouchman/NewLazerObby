using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishZone : MonoBehaviour
{
    public GameObject winUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Level Complete");

            // Show UI here (could load level later)

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            if (winUI != null){
                winUI.SetActive(true);

                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
