using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) //���� ������
    {
        if (GameManager.Instance.IsSprite == false //���̴� ȿ���� ����
            && collision.gameObject.CompareTag("Player") //���� ���� �÷��̾�鼭
            && GameManager.Instance.IsShield == false) //�������� ����
        {

        }
        else if (GameManager.Instance.IsSprite == false //���̴� ȿ���� ����
            && collision.gameObject.CompareTag("Player") //�������� �÷��̾�鼭
            && GameManager.Instance.IsShield == true) //�������� �ִ�
        {
            //Debug.Log("����!"); //�ѹ� ����
            GameManager.Instance.IsShield = false; //���� �� �����
            
        }
    }
}
