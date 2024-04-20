using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStage : MonoBehaviour
{
    [SerializeField]
    BattleManager battleManager;

    [SerializeField]
    BattleUI BattleUI;

    [SerializeField]
    Transform[] leftTrasforms = new Transform[5];
    [SerializeField]
    Transform[] rightTrasforms = new Transform[5];

    //��Ʋ ���� �� �ʱ�ȭ
    void Start()
    {
        CombatComponent[] combaters = FindObjectsOfType<CombatComponent>();

        for (int i = 0; i < combaters.Length; ++i)
        {
            combaters[i].BattleManager = battleManager;
            //�ӵ� ���� ������ �־�� ��.
            //�ƴϸ� �������� Ư�� ����
            battleManager.AddBattleColleague(combaters[i]);

            if (null != combaters[i].GetComponent<PlayableCharacter>())
            {
                BattleUI.AddCombater(combaters[i]);
            }
        }
        
        battleManager.Initialized();

        //��Ʋ ����
        StartCoroutine(battleManager.Battle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
