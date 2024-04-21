using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStage : MonoBehaviour
{
    [SerializeField]
    BattleManager battleManager;

    [SerializeField]
    BattleUI battleUI;

    [SerializeField]
    Transform[] leftTrasforms = new Transform[5];
    [SerializeField]
    Transform[] rightTrasforms = new Transform[5];

    //배틀 시작 전 초기화
    void Start()
    {
        CombatComponent[] combaters = FindObjectsOfType<CombatComponent>();

        for (int i = 0; i < combaters.Length; ++i)
        {
            combaters[i].BattleManager = battleManager;

            //속도 빠른 순으로 넣어야 함.
            //아니면 무작위나 특정 순서
            battleManager.AddBattleColleague(combaters[i]);

            if (null != combaters[i].GetComponent<PlayableCharacter>())
            {
                battleManager.AddCharacter(combaters[i]);
                combaters[i].CombatStart();
            }

            else if (null != combaters[i].GetComponent<Enemy>())
            {
                battleManager.AddEnemy(combaters[i]);
            }
        }

        battleUI.BattleManager = battleManager;
        battleManager.turnChanged += battleUI.OnTurnChanged;
        battleManager.Initialized();

        //배틀 시작
        StartCoroutine(battleManager.Battle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
