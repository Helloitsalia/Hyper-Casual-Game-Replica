using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tekrar_oyna : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    public void Tekrar_yukle()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       
    }
}
