using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (GameManager.IsSprite == false //���̴� ȿ���� ����
            && collision.gameObject.CompareTag("Player") //���� ���� �÷��̾�鼭
            && GameManager.IsShield == false) //�������� ����
        {
            Debug.Log("�ĸ���"); //�׷� �¾ƾ���
        }
        else if (GameManager.IsSprite == false //���̴� ȿ���� ����
            && collision.gameObject.CompareTag("Player") //�������� �÷��̾�鼭
            && GameManager.IsShield == true) //�������� �ִ�
        {
            Debug.Log("����!"); //�ѹ� ����
            GameManager.IsShield = false; //���� �� �����
            
        }
    }
}
