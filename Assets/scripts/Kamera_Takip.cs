using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera_Takip : MonoBehaviour
{
    public GameObject hang_obje;
    Vector3 fark;
    float y;
    // Start is called before the first frame update
    void Start()
    {
        y = transform.position.y;
        fark = transform.position - hang_obje.transform.position;
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = hang_obje.transform.position + fark;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
