using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    //���� �ټ���
    //�Ӽ� ����

    //�극��ũ(�극��ũ���� ���� Ƚ��
    //�극��ũ����Ʈ�� 0�� �Ǹ� ����
    int braekPoint;
    AttributeSet attribute;

    void Start()
    {
        attribute = GetComponent<AttributeSet>();
    }

    void Update()
    {
        
    }
}
