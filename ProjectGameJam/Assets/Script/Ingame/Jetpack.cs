using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Player")) //������ �÷��̾���
        {
            GameManager.Instance.IsItemJetpack = true; //��Ʈ�� �������� ���
            Destroy(this.gameObject); //�������� ����(�μ�)
        }
    }
}
