using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Animator anim;

    public static int Count = 0; //점수 합계
    public static int MaxCount = 0; //최고 점수

    public static int SmallCoin = 20; //작은 코인 점수
    public static int BigCoin = 50; //큰 코인 점수

    public GameObject BackGround;

    public Text CountText;
    public Text MaxText;

    public Vector3 Vec = new Vector3(40, -10, 0);
    public GameObject[] Ground;

    public float SpriteTime = 1.5f;

    public bool IsItemSprite = false; //사이다 아이템을 먹었는가
    public bool IsItemShield = false; //포장지 아이템을 먹었는가
    public bool IsItemJetpack = false; //제트팩 아이템을 먹었는가
    public bool IsSprite = false; //사이다 아이템이 유지되고 있는가
    public bool IsShield = false; //포장지 아이템이 유지되고 있는가

    public GameObject P; //플레이어
    public float MoveSpeed; //플랫폼의 이동속도
    public GameObject Barrier; //포장지
    Player player;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Barrier.gameObject.SetActive(false); //포장지 효과는 꺼짐
        player = GetComponent<Player>();
        StartCoroutine(Spawn());

    }
    IEnumerator color() //사이다 지속시간동안 반투명하게 바꿈
    {
        IsSprite = true;
        P.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSecondsRealtime(SpriteTime);
        P.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        IsSprite = false;
    }

    void Update()
    {

        CountText.text = "점수 : " + Count;
        MaxText.text = "최고점수 : " + MaxCount;

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
        if (Count >= 4000)
        {
            BackGround.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
        if (Count >= 10000)
        {
            SceneManager.LoadScene("StoryScene4");
        }
    }
    IEnumerator Spawn()
    {
        Instantiate(Ground[Random.Range(0, 4)], Vec, Quaternion.identity);
        yield return new WaitForSeconds(0.8f / (MoveSpeed / 50));
        StartCoroutine(Spawn());
    }
}
