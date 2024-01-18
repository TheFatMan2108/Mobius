using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D rb;
    Vector3 RespawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        RespawnPoint = transform.position;
    }

    private void Update()
    {




    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Moster") || collision.CompareTag("bay"))
        {
            if (animator.GetBool("runDead"))
            {
                animator.SetBool("runDead", false);
                

            }
            rb.bodyType = RigidbodyType2D.Static;
            animator.SetTrigger("isDead");
        }
        else if (collision.CompareTag("dauQuaiVat"))
        {
            Destroy(collision.transform.parent.gameObject);
            Debug.Log("Ddang chay");
        }

    }

    public void reSpawn()
    {

        UI_Mananger.mang_--;
        if (UI_Mananger.mang_ <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            UI_Mananger.mang_ = 3;
            UI_Mananger.diem_ = 0;
        }
        else
        {
            transform.position = RespawnPoint;
            animator.SetBool("runDead", true);
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

    }


}
