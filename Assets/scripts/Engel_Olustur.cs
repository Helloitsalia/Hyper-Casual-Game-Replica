using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Engel_Olustur : MonoBehaviour
{

    const float MIN = 0.3f;
    const float MAX = 2f;
    float mesafe = 15f;
    int sayac = 0;
    public Material materiall;
    // Start is called before the first frame update
    void Start()
    {

	Engel.gecilen_adet = 0;
        Engelolustur();
        Engelolustur();
    }
    
    public void Engelolustur()
    {
        GameObject engel_objesi = new GameObject("Engel");
        Engel engel_sc = engel_objesi.AddComponent<Engel>();
        float aralik = Random.Range(0, 1.7f);
        float x = aralik + 0.3f;
        float y = 2f - aralik + 0.3f;
        engel_sc.Collider_olustur(x, y);
        engel_objesi.transform.position = new Vector3(0, 0, sayac * mesafe+5f);
        Vector3 scal = new Vector3(2f - x / 2, y, 1f);
        Vector3 pos = new Vector3(-2f + scal.x / 2, scal.y / 2, 0);
        Duvar_Olustur(scal, pos, engel_objesi.transform);
        pos = new Vector3(2f - scal.x / 2, scal.y / 2, 0);
        Duvar_Olustur(scal, pos, engel_objesi.transform);
        scal = new Vector3(4f, 1f, 1f);
        pos = new Vector3(0f, y + .5f, 0f);
        Duvar_Olustur(scal, pos, engel_objesi.transform);
        sayac++;
    }
    public void Duvar_Olustur(Vector3 buyukluk,Vector3 konum,Transform parent)
    {
        GameObject duvar = GameObject.CreatePrimitive(PrimitiveType.Cube);
        duvar.transform.localScale = buyukluk;
        duvar.transform.parent = parent;
        duvar.transform.localPosition = konum;
        duvar.GetComponent<MeshRenderer>().material = materiall;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

     public void OnButtonClick(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}