using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake_move : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    float tocDo = 3f;
    float ngang;

    private void Start()
    {
        ngang = -1;
    }
    private void Update()
    {
        transform.Translate(new Vector3(ngang,0,0) * tocDo * Time.deltaTime);
        transform.localScale = new Vector3(ngang, transform.localScale.y);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("trigger"))
        {
            ngang *= -1;
          
        }
    }
}
