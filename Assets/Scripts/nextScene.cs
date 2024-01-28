using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene1 : MonoBehaviour
{
    [SerializeField] private string nameScene;
    public static string KEY_HEALTH="health";
    public static string KEY_COINS="coins";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("dich"))
        {
            SceneManager.LoadScene(nameScene);
            AudioManager.instance.PlaySFX("teleport");
            PlayerPrefs.SetInt(KEY_HEALTH,UI_Mananger.mang_);
            PlayerPrefs.SetInt(KEY_COINS,UI_Mananger.diem_);
            PlayerPrefs.Save();
        }
    }
}
