using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewLaserScript : MonoBehaviour
{
    private LineRenderer lr;
    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private Transform respawnPoint;


    void Start(){
        lr = GetComponent<LineRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, startPoint.position);
        RaycastHit hit;
        if(Physics.Raycast(startPoint.position, startPoint.forward, out hit)){
            if(hit.collider){
                lr.SetPosition(1, hit.point);
                 Debug.Log("Laser hit: " + hit.collider.name);
            }
            if(hit.transform.tag == "Player"){
                Destroy(hit.transform.gameObject);
            }
        }
        else lr.SetPosition(1, startPoint.position + startPoint.forward * 5000);

    }
}
