using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_inGame : MonoBehaviour
{
   [SerializeField] GameObject m_Menu;
    public void tamDung()
    {
        Time.timeScale = 0f;
        m_Menu.SetActive(true);
    }
    public void tiepTuc()
    {
        Time.timeScale = 1.0f;
        m_Menu.SetActive(false);
    }

    public void thoat()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

}
