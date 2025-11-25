using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class TimeScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] float remainTime;
    [SerializeField] GameObject losePanel;

    bool checkLose = false;
    // Update is called once per frame
    void Update()
    {
        if (!checkLose){
            if (remainTime > 0){
                remainTime -= Time.deltaTime;
            }
            else{
                remainTime = 0;
                timeText.color = Color.red;
                lose();
            }
        }
        
        int min = Mathf.FloorToInt(remainTime / 60);
        int sec = Mathf.FloorToInt(remainTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    void lose(){
        checkLose = true;
        losePanel.SetActive(true);

        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
