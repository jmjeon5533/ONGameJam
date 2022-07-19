using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{

    public float FirstJump = 15;  //첫 점프 속도
    public float SecondJump = 21; //두번째 점프 속도
    Rigidbody2D rbody;
    [SerializeField] int JumpCount = 1; //점프 횟수
    public float hitRay = 2.42f; //바닥 판정 길이
    public float WaitTime = 0.4f; // 점프 ~ 2단점프 사이 쿨타임
    GameManager GM;
    SpriteRenderer Sp;
    public float transformY;
    public float SaveSpeed = 0.6f;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        GM = GetComponent<GameManager>();
        Sp = GetComponent<SpriteRenderer>();
        StartCoroutine(Save());

    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //Space를 누르면 점프
        {
            if (JumpCount == 1)
            {
                rbody.AddForce(Vector2.up * FirstJump, ForceMode2D.Impulse);
                //점프한다

                //동시에 0.2초 미루기(미루는 동안 2단점프 사용불가)
                for (float i = 0 * Time.deltaTime; i < WaitTime; i += 0.02f)
                {
                    //Debug.Log(i);
                }
                JumpCount = 2; // 2단점프 사용 가능
            }
            else if (JumpCount == 2)
            {
                rbody.AddForce(Vector2.up * SecondJump, ForceMode2D.Impulse);
                //점프한다

                JumpCount = 3; //점프 사용 불가
            }
        }
    }
    public void Dead()
    {
        Debug.Log("으앙 쥬금");
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
        }   
    }
    IEnumerator Save()
    {
        while (true)
        {
            if (gameObject.transform.position.y <= -15 && GameManager.IsItemJetpack)
            //플레이어가 -15 밑으로 떨어졌을때 제트팩 아이템이 있다면
            {
                rbody.gravityScale = 0;
                GameManager.IsItemSprite = true; 
                //Debug.Log("떨어짐/제트팩 있음");
                for (; transform.position.y <= 4;) 
                {
                    gameObject.transform.Translate(0, transformY/50, 0);
                    yield return new WaitForSeconds(0.01f);
                }
                rbody.gravityScale = 5;
                GameManager.IsItemJetpack = false;

            }
            else if (gameObject.transform.position.y <= -15 && !GameManager.IsItemJetpack)
            //플레이어가 -15 밑으로 떨어졌을 때 제트팩 아이템이 없다면
            {
                //Debug.Log("떨어짐/제트팩 없음");
                Dead(); // 죽음
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}

