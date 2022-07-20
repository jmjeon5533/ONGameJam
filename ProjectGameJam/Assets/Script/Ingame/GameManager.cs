using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Animator anim;

    public static int Count = 0; //���� �հ�
    public static int MaxCount = 0; //�ְ� ����

    public static int SmallCoin = 20; //���� ���� ����
    public static int BigCoin = 50; //ū ���� ����

    public GameObject BackGround;

    public Text CountText;
    public Text MaxText;

    public Vector3 Vec = new Vector3(40, -10, 0);
    public GameObject[] Ground;

    public float SpriteTime = 1.5f;

    public bool IsItemSprite = false; //���̴� �������� �Ծ��°�
    public bool IsItemShield = false; //������ �������� �Ծ��°�
    public bool IsItemJetpack = false; //��Ʈ�� �������� �Ծ��°�
    public bool IsSprite = false; //���̴� �������� �����ǰ� �ִ°�
    public bool IsShield = false; //������ �������� �����ǰ� �ִ°�

    public GameObject P; //�÷��̾�
    public float MoveSpeed; //�÷����� �̵��ӵ�
    public GameObject Barrier; //������
    Player player;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Barrier.gameObject.SetActive(false); //������ ȿ���� ����
        player = GetComponent<Player>();
        StartCoroutine(Spawn());

    }
    IEnumerator color() //���̴� ���ӽð����� �������ϰ� �ٲ�
    {
        IsSprite = true;
        P.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSecondsRealtime(SpriteTime);
        P.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        IsSprite = false;
    }

    void Update()
    {

        CountText.text = "���� : " + Count;
        MaxText.text = "�ְ����� : " + MaxCount;

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
