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
        if (gameObject.transform.position.x <= -40) // x가 -40을 넘어가면
        {
            Destroy(gameObject); //파괴
        }

    }
    private void FixedUpdate()
    {
        transform.Translate(-GameManager.Instance.MoveSpeed/50, 0, 0);
         //이동속도로 무빙맨
    }
}
