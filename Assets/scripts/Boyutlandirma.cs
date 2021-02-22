using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boyutlandirma : MonoBehaviour
{
   const float MIN = 0.3f;
   const  float MAX = 2f;
   public float x, y;
    Vector3 son_konum;
    bool basma_aktif_mi = true;
    // Start is called before the first frame update
    void Start()
    {
        x = transform.localScale.x;
        y = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        Ayarla();   
    }
    void Ayarla()
    {

#if UNITY_ANDROID
        Telefon();
#elif UNITY_IPHONE
        Telefon();
#else
        Pc();
#endif

    }
    void Telefon()
    {
        if (Input.touchCount>0)
        {
            if (basma_aktif_mi)
            {
                son_konum = Input.GetTouch(0).position;
                basma_aktif_mi = false;
                return;
            }
            float fark = Input.GetTouch(0).position.y - son_konum.y;
            if (fark > 0)
            {
                x -= Time.deltaTime * fark;
                y += Time.deltaTime * fark;
            }
            else
            {
                x -= Time.deltaTime * fark;
                y += Time.deltaTime * fark;
            }
            son_konum = Input.GetTouch(0).position;
            x = Mathf.Clamp(x, MIN, MAX);
            y = Mathf.Clamp(y, MIN, MAX);
            transform.localScale = new Vector3(x, y, 1);
            transform.position = new Vector3(0, y / 2, transform.position.z);
        }
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                basma_aktif_mi = true;
            }
        }
    }
    void Pc()
    {
        if (Input.GetMouseButton(0))
        {
            if (basma_aktif_mi)
            {
                son_konum = Input.mousePosition;
                basma_aktif_mi = false;
                return;
            }
            float fark = Input.mousePosition.y - son_konum.y;
            if (fark > 0)
            {
                x -= Time.deltaTime * fark;
                y += Time.deltaTime * fark;
            }
            else
            {
                x -= Time.deltaTime * fark;
                y += Time.deltaTime * fark;
            }
            son_konum = Input.mousePosition;
            x = Mathf.Clamp(x, MIN, MAX);
            y = Mathf.Clamp(y, MIN, MAX);
            transform.localScale = new Vector3(x, y, 1);
            transform.position = new Vector3(0, y / 2, transform.position.z);
        }
        if (Input.GetMouseButtonUp(0))
        {
            basma_aktif_mi = true;
        }
    }


}
