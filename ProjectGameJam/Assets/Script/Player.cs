using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public float FirstJump = 17;  //ù ���� �ӵ�
    public float SecondJump = 23; //�ι�° ���� �ӵ�
    Rigidbody2D rbody;
    [SerializeField] int JumpCount = 1; //���� Ƚ��
    public float hitRay = 2.42f; //�ٴ� ���� ����
    public float WaitTime = 0.4f; // ���� ~ 2������ ���� ��Ÿ��
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
        if (Input.GetKeyDown(KeyCode.Space)) //Space�� ������ ����
        {
            if (JumpCount == 1)
            {
                rbody.AddForce(Vector2.up * FirstJump, ForceMode2D.Impulse);
                //�����Ѵ�

                //���ÿ� 0.2�� �̷��(�̷�� ���� 2������ ���Ұ�)
                for (float i = 0 * Time.deltaTime; i < WaitTime; i += 0.02f)
                {
                    //Debug.Log(i);
                }
                JumpCount = 2; // 2������ ��� ����
            }
            else if (JumpCount == 2)
            {
                rbody.AddForce(Vector2.up * SecondJump, ForceMode2D.Impulse);
                //�����Ѵ�

                JumpCount = 3; //���� ��� �Ұ�
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
            JumpCount = 1; //���� ��� ����
        }
    }
}

