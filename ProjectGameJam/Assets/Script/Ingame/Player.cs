using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    public float FirstJump;  //첫 점프 속도
    Rigidbody2D rbody;
    BoxCollider2D BoxCol;
    [SerializeField] int JumpCount = 1; //점프 횟수
    public float hitRay = 2.42f; //바닥 판정 길이
    public float WaitTime = 0.4f; // 점프 ~ 2단점프 사이 쿨타임
    GameManager GM;
    SpriteRenderer Sp;
    public float transformY;
    public float SaveSpeed = 0.6f;
    public float JumpPower;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        GM = GetComponent<GameManager>();
        Sp = GetComponent<SpriteRenderer>();
        StartCoroutine(Save());
        BoxCol = GetComponent<BoxCollider2D>();
        JumpPower = FirstJump;

    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //Space를 누르면 점프
        {
            if (JumpCount == 1)
            {
                rbody.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
                //점프한다

                //동시에 0.2초 미루기(미루는 동안 2단점프 사용불가)
                for (float i = 0 * Time.deltaTime; i < WaitTime; i += 0.02f)
                {
                    //Debug.Log(i);
                }
                JumpCount = 2; // 2단점프 사용 가능
            }
        }
    }
    public void Dead()
    {
        if (GameManager.Count > GameManager.MaxCount)
        {
            GameManager.MaxCount = GameManager.Count;
        }
        GameManager.Count = 0;
        SceneManager.LoadScene("GameOver");
    }

    // Update is called once per frame
    void Update()
    {
        Jump(); //점프 함수 계속 실행
        Debug.DrawRay(rbody.position, new Vector2(0, -hitRay), Color.red); //레이를 보이게 처리

        RaycastHit2D HitObject = Physics2D.Raycast(rbody.position, Vector2.down, hitRay, LayerMask.GetMask("Ground"));
        //아래로 바닥만을 판정하는 레이 발사

        if (HitObject.collider != null) //바닥에 닿았다면
        {
            //Debug.Log(HitObject.collider.gameObject.name);
            JumpCount = 1; //점프 사용 가능
            JumpPower = FirstJump;
        }
        else if (HitObject.collider == null)
        {
            JumpPower = FirstJump - 15;
        }
    }
    IEnumerator Save()
    {
        while (true)
        {
            if (gameObject.transform.position.y <= -25 && GameManager.Instance.IsItemJetpack)
            //플레이어가 -15 밑으로 떨어졌을때 제트팩 아이템이 있다면
            {
                BoxCol.isTrigger = true; //콜라이더 충돌 무효
                GameManager.Instance.SpriteTime = 5; //사이다 무적 효과 - 5초로 바꿈
                GameManager.Instance.IsItemSprite = true; //사이다 무적 효과 실행
                for (; transform.position.y <= -20;) //위로 끌어올림
                {
                    rbody.AddForce(Vector2.up * transformY);
                    yield return new WaitForSeconds(0.01f);
                }
                GameManager.Instance.SpriteTime = 1.5f; //사이다 무적 효과 - 다시 1.5초로
                yield return new WaitForSeconds(1); 
                BoxCol.isTrigger = false; //콜라이더 충돌 유효
                GameManager.Instance.IsItemJetpack = false; //제트팩 사용 완료

            }
            else if (gameObject.transform.position.y <= -25 && !GameManager.Instance.IsItemJetpack)
            //플레이어가 -15 밑으로 떨어졌을 때 제트팩 아이템이 없다면
            {
                Dead(); // 죽음
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}

