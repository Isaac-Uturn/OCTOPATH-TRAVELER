using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyCombatComponent : CombatComponent
{
    public override void ChooseRandomAction()
    {
        base.ChooseRandomAction();

        //�÷��̾� ĳ���� Ÿ�� ����
        PlayableCharacter[] characters = FindObjectsOfType<PlayableCharacter>();
        PlayableCharacter charcter = characters[UnityEngine.Random.Range(0, characters.Length)];

        Target = charcter.GetComponent<CombatComponent>();
    }

}
