using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    public float MoveSpeed;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.Translate(-MoveSpeed/50, 0, 0);
    }
}
