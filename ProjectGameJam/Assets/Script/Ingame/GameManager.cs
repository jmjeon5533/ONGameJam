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

    public static bool IsItemSprite = false; //���̴� �������� �Ծ��°�
    public static bool IsItemShield = false; //������ �������� �Ծ��°�
    public static bool IsItemJetpack = false; //��Ʈ�� �������� �Ծ��°�
    public static bool IsSprite = false; //���̴� �������� �����ǰ� �ִ°�
    public static bool IsShield = false; //������ �������� �����ǰ� �ִ°�

    public GameObject P; //�÷��̾�
    public static float MoveSpeed; //�÷����� �̵��ӵ�
    public float FlatformSpeed; //�÷����� �̵��ӵ��� inspector���� ������ ����
    public GameObject Barrier; //������
    Player player;
    void Start()
    {
        Barrier.gameObject.SetActive(false); //������ ȿ���� ����
        player = GetComponent<Player>();

    }
    IEnumerator color() //���̴� ���ӽð����� �������ϰ� �ٲ�
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

        if (IsItemSprite) //���̴� �������� ������
        {
            IsItemSprite = false; //���̴ٸ� false�� 
            StartCoroutine(color()); //���̴� ȿ�� ���� - Enemy�� ����
        }
        if (IsItemShield) //������ �������� ������
        {
            IsItemShield = false; //�������� false��
            IsShield = true; //������ ȿ�� ���� - Enemy�� ����
            
        }
        if (IsShield) //�������� �������϶�
        {
            Barrier.gameObject.SetActive(true); //������ ����Ʈ�� ���
        }
        else if (!IsShield) //�������� ���������
        {
            Barrier.gameObject.SetActive(false); //������ ����Ʈ�� ����
        }
        if (IsItemJetpack) //��Ʈ���� �������϶�
        {
            anim.SetBool("IsJetPack", true); //��Ʈ���� � ��
        }
        else if (!IsItemJetpack) //��Ʈ���� ���� ��
        {
            anim.SetBool("IsJetPack", false); //��Ʈ�� �����
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
