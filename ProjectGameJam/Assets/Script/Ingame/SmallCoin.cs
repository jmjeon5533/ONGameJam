using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCoin : MonoBehaviour
{
    GameManager GM;
    // Start is called before the first frame update
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
            GameManager.Count = GameManager.Count + GameManager.SmallCoin;
            Destroy(gameObject);
        }
    }
}
