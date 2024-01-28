using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChuyenScene : MonoBehaviour
{
    public static ChuyenScene instance;
    [SerializeField] GameObject setting;
 
    public void batDau()
    {
        SceneManager.LoadScene("LV1");       
    }
    public void thoat() 
    {
    Application.Quit();
    }

    public void openSetting()
    {
      setting.SetActive(true);
    }

    public void closeSetting()
    {
        setting.SetActive(false);
    }

    private void Awake()
    {
       

    }

}
