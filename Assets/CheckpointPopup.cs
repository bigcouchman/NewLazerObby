using UnityEngine;
using TMPro;
using System.Collections;

public class CheckpointPopup : MonoBehaviour
{
    public static CheckpointPopup Instance;
    [SerializeField] GameObject popup;
    [SerializeField] float visibleTime = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        Instance = this;
        popup.SetActive(false);
    }

    // Update is called once per frame
    public void ShowPopUp()
    {
        popup.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(HideAfterDelay());
        Debug.Log("Popup visible.");
    }

    private IEnumerator HideAfterDelay(){
        yield return new WaitForSeconds(visibleTime);
        popup.SetActive(false);
    }
}
