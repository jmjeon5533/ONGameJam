using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{

    public float FirstJump = 15;  //ù ���� �ӵ�
    public float SecondJump = 21; //�ι�° ���� �ӵ�
    Rigidbody2D rbody;
    [SerializeField] int JumpCount = 1; //���� Ƚ��
    public float hitRay = 2.42f; //�ٴ� ���� ����
    public float WaitTime = 0.4f; // ���� ~ 2������ ���� ��Ÿ��
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
    public void Dead()
    {
        Debug.Log("���� ���");
    }

    // Update is called once per frame
    void Update()
    {
        Jump(); //���� �Լ� ��� ����
        Debug.DrawRay(rbody.position, new Vector2(0, -hitRay), Color.red); //���̸� ���̰� ó��

        RaycastHit2D HitObject = Physics2D.Raycast(rbody.position, Vector2.down, hitRay, LayerMask.GetMask("Ground"));
        //�Ʒ��� �ٴڸ��� �����ϴ� ���� �߻�

        if (HitObject.collider != null) //�ٴڿ� ��Ҵٸ�
        {
            //Debug.Log(HitObject.collider.gameObject.name);
            JumpCount = 1; //���� ��� ����
        }   
    }
    IEnumerator Save()
    {
        while (true)
        {
            if (gameObject.transform.position.y <= -15 && GameManager.IsItemJetpack)
            //�÷��̾ -15 ������ ���������� ��Ʈ�� �������� �ִٸ�
            {
                rbody.gravityScale = 0;
                GameManager.IsItemSprite = true; 
                //Debug.Log("������/��Ʈ�� ����");
                for (; transform.position.y <= 4;) 
                {
                    gameObject.transform.Translate(0, transformY/50, 0);
                    yield return new WaitForSeconds(0.01f);
                }
                rbody.gravityScale = 5;
                GameManager.IsItemJetpack = false;

            }
            else if (gameObject.transform.position.y <= -15 && !GameManager.IsItemJetpack)
            //�÷��̾ -15 ������ �������� �� ��Ʈ�� �������� ���ٸ�
            {
                //Debug.Log("������/��Ʈ�� ����");
                Dead(); // ����
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}

