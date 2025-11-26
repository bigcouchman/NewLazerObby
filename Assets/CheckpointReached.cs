using UnityEngine;

public class CheckpointReached : MonoBehaviour
{
    public bool isActive = false;
    public CheckpointPopup checkPop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Checkpoint hit. checkPop is: " + checkPop);

        if (other.CompareTag("Player"))
        {
            CheckpointManager.Instance.SetActiveCheckpoint(this);
            if (checkPop != null){
                checkPop.ShowPopUp();
            }
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
