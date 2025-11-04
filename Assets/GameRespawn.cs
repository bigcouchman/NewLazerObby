using UnityEngine;

public class GameRespawn : MonoBehaviour
{
    public float threshold;
    
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        // this is where we will set checkpoint 
        if (transform.position.y < threshold)
        {
            if (CheckpointManager.Instance != null)
            {
                transform.position = CheckpointManager.Instance.GetRespawnPos();
            }
            else
            {
                transform.position = new Vector3(0f, 5.926f, 0f);
                // debug whether checkpoint is saved or found
                Debug.Log("CheckpointManager not founded!");
            }
        }
    }
}
