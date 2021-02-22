using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Engel : MonoBehaviour
{ float x, y;
    public static int gecilen_adet = 0;
    // Start iscalled before the first frame update
    void Start()
    {
        
    }
    public void Collider_olustur(float _x, float _y)
    {
        BoxCollider box = gameObject.AddComponent<BoxCollider>();
        box.size = new Vector3(_x, _y, 1f);
        x = _x;
        y = _y;
        box.isTrigger = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Boyutlandirma b = other.GetComponent<Boyutlandirma>();
            if (b.x <= x && b.y <= y)
            {
                GameObject.FindGameObjectWithTag("Respawn").GetComponent<Engel_Olustur>().Engelolustur();
                gecilen_adet++;
                GameObject.Find("text_adet").GetComponent<Text>().text = gecilen_adet.ToString();
                Destroy(gameObject, 2f);
            }
            else 
            {
                Time.timeScale = 0f;
                Debug.Log("GameOver");
                GameObject.Find("Tekrar_Oynama").GetComponent<Tekrar_oyna>().panel.SetActive(true);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
