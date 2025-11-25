using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class TimeScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] float remainTime;

    // Update is called once per frame
    void Update()
    {
        if (remainTime > 0){
            remainTime -= Time.deltaTime;
        }
        else if (remainTime < 0){
            remainTime = 0;
            timeText.color = Color.red;
        }
        int min = Mathf.FloorToInt(remainTime / 60);
        int sec = Mathf.FloorToInt(remainTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}
