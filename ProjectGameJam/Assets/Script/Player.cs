using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public float FirstJump = 17;  //첫 점프 속도
    public float SecondJump = 23; //두번째 점프 속도
    Rigidbody2D rbody;
    [SerializeField] int JumpCount = 1; //점프 횟수
    public float hitRay = 2.42f; //바닥 판정 길이
    public float WaitTime = 0.4f; // 점프 ~ 2단점프 사이 쿨타임
    GameManager GM;
    SpriteRenderer Sp;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        GM = GetComponent<GameManager>();
        Sp = GetComponent<SpriteRenderer>();

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



    // Update is called once per frame
    void Update()
    {
        Jump();
        Debug.DrawRay(rbody.position, new Vector2(0, -hitRay), Color.red);

        RaycastHit2D HitObject = Physics2D.Raycast(rbody.position, Vector2.down, hitRay, LayerMask.GetMask("Ground"));

        if (HitObject.collider != null)
        {
            //Debug.Log(HitObject.collider.gameObject.name);
            JumpCount = 1; //점프 사용 가능
        }
    }
}

