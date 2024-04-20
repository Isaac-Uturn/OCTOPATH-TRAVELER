using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    //약점 다섯개
    //속성 무기

    //브레이크(브레이크까지 남은 횟수
    //브레이크포인트가 0이 되면 기절
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
