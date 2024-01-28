using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_inGame : MonoBehaviour
{
   [SerializeField] GameObject m_Menu_pauseGame;
   [SerializeField] GameObject m_Menu_endGame;
   [SerializeField] GameObject setting;
    public void tamDung()
    {
        Time.timeScale = 0f;
        m_Menu_pauseGame.SetActive(true);
    }
    public void tiepTuc()
    {
        Time.timeScale = 1.0f;
        m_Menu_pauseGame.SetActive(false);
    }

    public void thoat()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
       
    }

    public void choiLai()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        m_Menu_endGame.SetActive(false);
        Time.timeScale = 1.0f;  
    }

    public void endGame()
    {
        m_Menu_endGame.SetActive(true);
        Time.timeScale = 0f;
    }
    public void openCaiDat()
    {
        setting.SetActive(true);
    }
    public void closeCaiDat()
    {
        setting.SetActive(false);
    }

}
