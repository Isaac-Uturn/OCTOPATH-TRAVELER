using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int hp;
    int maxHp;

    //���� �ټ���
    //�Ӽ� ����

    //�극��ũ(�극��ũ���� ���� Ƚ��
    //�극��ũ����Ʈ�� 0�� �Ǹ� ����
    int braekPoint;

    Animator enemyAnim;


    void Start()
    {
        enemyAnim = GetComponent<Animator>();
    }


    void Update()
    {
        
    }
}
