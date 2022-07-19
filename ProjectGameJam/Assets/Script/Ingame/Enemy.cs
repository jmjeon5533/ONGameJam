using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) //무언가 닿으면
    {
        if (GameManager.IsSprite == false //사이다 효과가 없고
            && collision.gameObject.CompareTag("Player") //닿은 것이 플레이어면서
            && GameManager.IsShield == false) //포장지도 없다
        {
            Debug.Log("쳐맞음"); //그럼 맞아야지
        }
        else if (GameManager.IsSprite == false //사이다 효과가 없고
            && collision.gameObject.CompareTag("Player") //닿은것이 플레이어면서
            && GameManager.IsShield == true) //포장지가 있다
        {
            Debug.Log("막음!"); //한번 막음
            GameManager.IsShield = false; //막은 후 사라짐
            
        }
    }
}
