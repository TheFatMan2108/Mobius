using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowPlayer : MonoBehaviour
{
    [SerializeField] Transform Player_positoin;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = new Vector3(Player_positoin.position.x,transform.position.y); 
    }
}
