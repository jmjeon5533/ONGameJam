using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    public float FirstJump;  //ù ���� �ӵ�
    Rigidbody2D rbody;
    BoxCollider2D BoxCol;
    [SerializeField] int JumpCount = 1; //���� Ƚ��
    public float hitRay = 2.42f; //�ٴ� ���� ����
    public float WaitTime = 0.4f; // ���� ~ 2������ ���� ��Ÿ��
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
        if (Input.GetKeyDown(KeyCode.Space)) //Space�� ������ ����
        {
            if (JumpCount == 1)
            {
                rbody.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
                //�����Ѵ�

                //���ÿ� 0.2�� �̷��(�̷�� ���� 2������ ���Ұ�)
                for (float i = 0 * Time.deltaTime; i < WaitTime; i += 0.02f)
                {
                    //Debug.Log(i);
                }
                JumpCount = 2; // 2������ ��� ����
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
        Jump(); //���� �Լ� ��� ����
        Debug.DrawRay(rbody.position, new Vector2(0, -hitRay), Color.red); //���̸� ���̰� ó��

        RaycastHit2D HitObject = Physics2D.Raycast(rbody.position, Vector2.down, hitRay, LayerMask.GetMask("Ground"));
        //�Ʒ��� �ٴڸ��� �����ϴ� ���� �߻�

        if (HitObject.collider != null) //�ٴڿ� ��Ҵٸ�
        {
            //Debug.Log(HitObject.collider.gameObject.name);
            JumpCount = 1; //���� ��� ����
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
            //�÷��̾ -15 ������ ���������� ��Ʈ�� �������� �ִٸ�
            {
                BoxCol.isTrigger = true; //�ݶ��̴� �浹 ��ȿ
                GameManager.Instance.SpriteTime = 5; //���̴� ���� ȿ�� - 5�ʷ� �ٲ�
                GameManager.Instance.IsItemSprite = true; //���̴� ���� ȿ�� ����
                for (; transform.position.y <= -20;) //���� ����ø�
                {
                    rbody.AddForce(Vector2.up * transformY);
                    yield return new WaitForSeconds(0.01f);
                }
                GameManager.Instance.SpriteTime = 1.5f; //���̴� ���� ȿ�� - �ٽ� 1.5�ʷ�
                yield return new WaitForSeconds(1); 
                BoxCol.isTrigger = false; //�ݶ��̴� �浹 ��ȿ
                GameManager.Instance.IsItemJetpack = false; //��Ʈ�� ��� �Ϸ�

            }
            else if (gameObject.transform.position.y <= -25 && !GameManager.Instance.IsItemJetpack)
            //�÷��̾ -15 ������ �������� �� ��Ʈ�� �������� ���ٸ�
            {
                Dead(); // ����
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}

