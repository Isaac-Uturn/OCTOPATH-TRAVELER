using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //���� �ټ���
    //�Ӽ� ����

    //�극��ũ(�극��ũ���� ���� Ƚ��
    //�극��ũ����Ʈ�� 0�� �Ǹ� ����
    int braekPoint;

    Animator animator;
    SpriteRenderer spriteRenderer;
    AttributeSet attribute;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        attribute = GetComponent<AttributeSet>();
    }

    void Update()
    {
        
    }
}
