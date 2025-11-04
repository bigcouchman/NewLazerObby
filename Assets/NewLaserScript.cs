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
            }
            if(hit.transform.tag == "Player"){
                hit.transform.position = new Vector3(0f, 5.926f, 0f);
                Vector3 respawnPoint = new Vector3(0f, 5.926f, 0f);
                CharacterController control = hit.transform.GetComponent<CharacterController>();
                if (control != null){
                    control.enabled = false;
                    hit.transform.position = respawnPoint;
                    control.enabled = true;
                }
                else {
                    hit.transform.position = respawnPoint;
                }
            }
        }
        else {
            lr.SetPosition(1, startPoint.position + startPoint.forward * 5000);
        }
    }
}
