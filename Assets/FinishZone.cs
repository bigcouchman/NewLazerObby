using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class FinishZone : MonoBehaviour
{
    public GameObject winUI;
    public Image star1;
    public Image star2;
    public Image star3;

    private TimeScript timer;
    void Start(){
        timer = FindAnyObjectByType<TimeScript>();
    }
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

                int stars = timer.numStars();
                displayStars(stars);
            }
        }
    }

    void displayStars(int count){
        star1.gameObject.SetActive(false);
        star2.gameObject.SetActive(false);
        star3.gameObject.SetActive(false);

        if (count >= 1){
            star1.gameObject.SetActive(true);
        }
        if (count >= 2){
            star2.gameObject.SetActive(true);
        }
        if (count >= 3){
            star3.gameObject.SetActive(true);
        }
    }
}
