using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Player")) //닿은게 플레이어라면
        {
            GameManager.Instance.IsItemSprite = true; //사이다 아이템을 얻고
            Destroy(this.gameObject); //아이템을 먹음(부숨)
        }
    }
}
