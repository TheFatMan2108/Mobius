using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChuyenScene : MonoBehaviour
{
    public void batDau()
    {
        SceneManager.LoadScene("LV1");
    }
    public void thoat() 
    {
    Application.Quit();
    }
   
}
