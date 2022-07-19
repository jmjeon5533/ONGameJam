using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCoin : MonoBehaviour
{
    GameManager GM;
    void Start()
    {
        GM = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Count = GameManager.Count + GameManager.BigCoin;
            Destroy(gameObject);
        }
    }
}
