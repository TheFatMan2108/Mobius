using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene1 : MonoBehaviour
{
    [SerializeField] private AudioSource teleSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("dich"))
        {
            SceneManager.LoadScene("LVFinal");
            teleSound.Play();
        }
    }
}
