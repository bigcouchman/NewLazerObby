using UnityEngine;

public class GameRespawn : MonoBehaviour
{
    public float threshold;
    
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            transform.position = new Vector3(0f, 5.926f, 0f);
        }
    }
}
