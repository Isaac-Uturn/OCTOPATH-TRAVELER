using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BattleManager battleManager = FindObjectOfType<BattleManager>();

        Character[] characters = FindObjectsByType<Character>(FindObjectsSortMode.InstanceID);
        Enemy[] enemys = FindObjectsByType<Enemy>(FindObjectsSortMode.InstanceID);

        for (int i = 0; i < characters.Length; ++i)
        {
            characters[i].GetComponent<CombatComponent>().BattleManager = battleManager;
            battleManager.AddCharacter(characters[i].gameObject);
        }

        for (int i = 0; i < enemys.Length; ++i)
        {
            battleManager.AddEnemy(enemys[i].gameObject);
        }

        battleManager.Battle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
