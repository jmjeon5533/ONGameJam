using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    void Start()
    {

    }

    
    void Update()
    {
        if (gameObject.transform.position.x <= -40) // x°¡ -40À» ³Ñ¾î°¡¸é
        {
            Destroy(gameObject);
        }

    }
    private void FixedUpdate()
    {
        
        transform.Translate(-GameManager.MoveSpeed/50, 0, 0); //ÇÃ·§Æû ¼Óµµ·Î ¹«ºù¸Ç
    }
}
