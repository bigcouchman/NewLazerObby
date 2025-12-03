using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour
{
    public Light primLight;

    public float minDel = 0.05f;
    public float maxDel = 0.3f;
    public float changeIntensity = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (primLight == null){
            primLight = GetComponent<Light>();
        }
        StartCoroutine(FlickRT());
    }

    IEnumerator FlickRT(){
        while (true){
            primLight.enabled = true;
            primLight.intensity = changeIntensity;
            yield return new WaitForSeconds(Random.Range(minDel, maxDel));
            primLight.enabled = false;
            yield return new WaitForSeconds(Random.Range(minDel, maxDel));
        }
    }
}
