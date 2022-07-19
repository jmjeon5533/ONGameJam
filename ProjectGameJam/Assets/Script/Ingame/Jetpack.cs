using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
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
            GameManager.IsItemJetpack = true; //제트팩 아이템을 얻고
            Destroy(this.gameObject); //아이템을 먹음(부숨)
        }
    }
}
