using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (GameManager.Instance.IsSprite == false //사이다 효과가 없고
            && collision.gameObject.CompareTag("Player") //닿은 것이 플레이어면서
            && GameManager.Instance.IsShield == false) //포장지도 없다
        {

        }
        else if (GameManager.Instance.IsSprite == false //사이다 효과가 없고
            && collision.gameObject.CompareTag("Player") //닿은것이 플레이어면서
            && GameManager.Instance.IsShield == true) //포장지가 있다
        {
            //Debug.Log("막음!"); //한번 막음
            GameManager.Instance.IsShield = false; //막은 후 사라짐
            
        }
    }
}
