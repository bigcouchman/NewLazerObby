using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static CheckpointManager Instance;

    private CheckpointReached activeCheckpoint;
    private Vector3 startingPosition;

    // load the game object when user hits it
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    // game start, we track player
    public void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            startingPosition = player.transform.position;
        }
    }

    // set checkpoint and keep track of whether checkpoint is set during gameplay
    public void SetActiveCheckpoint(CheckpointReached checkpoint)
    {
        if (activeCheckpoint != null)
        {
            activeCheckpoint.isActive = false;
        }
        // set checkpoint to new
        activeCheckpoint = checkpoint;
        activeCheckpoint.isActive = true;

    }

    public Vector3 GetRespawnPos()
    {
        if (activeCheckpoint != null)
        {
            return activeCheckpoint.transform.position;
        } else
        {
            return startingPosition;
        }
    }
}
