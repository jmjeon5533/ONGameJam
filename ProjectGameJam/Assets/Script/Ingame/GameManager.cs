using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Animator anim;

    public static int Count = 0;

    public static int SmallCoin = 20;
    public static int BigCoin = 50;


    public Text CountText;

    public Vector3 Vec = new Vector3(40, 0, 0);
    public GameObject[] Ground;

    public static bool IsItemSprite = false; //사이다 아이템을 먹었는가
    public static bool IsItemShield = false; //포장지 아이템을 먹었는가
    public static bool IsItemJetpack = false; //제트팩 아이템을 먹었는가
    public static bool IsSprite = false; //사이다 아이템이 유지되고 있는가
    public static bool IsShield = false; //포장지 아이템이 유지되고 있는가

    public GameObject P; //플레이어
    public static float MoveSpeed; //플랫폼의 이동속도
    public float FlatformSpeed; //플랫폼의 이동속도를 inspector에서 조정할 변수
    public GameObject Barrier; //포장지
    Player player;
    void Start()
    {
        Barrier.gameObject.SetActive(false); //포장지 효과는 꺼짐
        player = GetComponent<Player>();

    }
    IEnumerator color() //사이다 지속시간동안 반투명하게 바꿈
    {
        IsSprite = true; 
        P.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSecondsRealtime(3);
        P.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        IsSprite = false;
    }

    void Update()
    {
        MoveSpeed = FlatformSpeed;

        CountText.text = "Score : " + Count;

        if (IsItemSprite) //사이다 아이템을 먹으면
        {
            IsItemSprite = false; //사이다를 false로 
            StartCoroutine(color()); //사이다 효과 실행 - Enemy로 참조
        }
        if (IsItemShield) //포장지 아이템을 먹으면
        {
            IsItemShield = false; //포장지를 false로
            IsShield = true; //포장지 효과 실행 - Enemy로 참조
            
        }
        if (IsShield) //포장지가 유지중일때
        {
            Barrier.gameObject.SetActive(true); //포장지 이펙트를 재생
        }
        else if (!IsShield) //포장지가 사라졌을때
        {
            Barrier.gameObject.SetActive(false); //포장지 이펙트를 중지
        }
        if (IsItemJetpack) //제트팩이 유지중일때
        {
            anim.SetBool("IsJetPack", true); //제트팩을 등에 맴
        }
        else if (!IsItemJetpack) //제트팩이 없을 때
        {
            anim.SetBool("IsJetPack", false); //제트팩 사라짐
        }
        /*
        for (int i = 0; i < 4; i++)
        {
            if (Ground[i].gameObject.transform.position.x <= 0)
            {
                Instantiate(Ground[Random.Range(0, 3)], Vec, Quaternion.identity);
            }
        }
        */
    }
}
