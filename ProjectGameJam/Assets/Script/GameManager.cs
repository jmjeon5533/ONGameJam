using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool IsItemSprite = false;
    public static bool IsItem = false;
    public GameObject P;
    void Start()
    {
        
    }
    IEnumerator color()
    {
        IsItem = true;
        P.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSecondsRealtime(3);
        P.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        IsItem = false;
    }

    void Update()
    {
        if (IsItemSprite)
        {
            IsItemSprite = false;
            StartCoroutine(color());
        }
    }
}
