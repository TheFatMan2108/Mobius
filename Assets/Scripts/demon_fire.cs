using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demon_fire : MonoBehaviour
{

    public void Destroy()
    {
        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}
