using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeSkill : MonoBehaviour
{
    [SerializeField] private GameObject bullet ;
    
    public void deSkill()
    {
        Destroy(gameObject);
        SpawnWeapon.casSkill = false;
    }

   public void SpawnBulet()
    {
      var dan =   Instantiate(bullet,new Vector3(transform.position.x+1* move.huong, transform.position.y+0,5),Quaternion.identity);
        dan.GetComponent<Rigidbody2D>().velocity = move.huong * transform.right * 6f;

    }

   
}
