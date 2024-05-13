using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BattleManager�� Battle ������ ������.
public class BattleManager : MonoBehaviour, IBattleMediator
{
    BattleTurn _currentTrun = BattleTurn.None;
    public BattleTurn CurrentTrun
    {
        get { return _currentTrun; }
        set
        {
            turnChanged(_currentTrun);
            _currentTrun = value;
        }
    }

    [SerializeField]
    BattleUI BattleUI;

    //IBattleColleague�� �����ص� �� �� ����.
    List<IBattleColleague> battleColleagues = new List<IBattleColleague>();
    
    public List<CombatComponent> characters = new List<CombatComponent>();
    public List<CombatComponent> enemies = new List<CombatComponent>();

    int currentActionIndex = 0;

    public delegate void TurnChanged(BattleTurn trun);
    public TurnChanged turnChanged;

    public void Initialized()
    {
        _currentTrun = BattleTurn.SelectAction;
        turnChanged(_currentTrun);
    }

    public void AddBattleColleague(IBattleColleague colleague)
    {
        battleColleagues.Add(colleague);
    }

    public void AddCharacter(CombatComponent component)
    {
        characters.Add(component);
    }

    public void AddEnemy(CombatComponent component)
    {
        enemies.Add(component);
    }

    public IEnumerator Battle()
    {
        while (true)
        {
            switch (CurrentTrun)
            {
                //��� �÷��̾�� ĳ���Ͱ� �׼��� ����.
                //�� ĳ���͵鵵 AI�� ���� �׼� ����
                case BattleTurn.SelectAction:
                    {
                        currentActionIndex = 0;

                        for (int i = 0; i < enemies.Count; ++i)
                        {
                            enemies[i].ChooseRandomAction();
                        }

                        yield return BattleUI.BattleUIEnable();

                        CurrentTrun = BattleTurn.Action;
                    }
                    break;

                //�ӵ��� ���� �Ӽ��� ���� �� ĳ���� �׼�
                //if: �׼��� ĳ���Ͱ� ���ٸ� �ٽ� Select.
                case BattleTurn.Action:
                    {
                        yield return battleColleagues[currentActionIndex].Notify();

                        CurrentTrun = BattleTurn.ActionEnd;
                    }
                    break;

                //�׼� ���� ó��
                case BattleTurn.ActionEnd:
                    {
                        ++currentActionIndex;

                        //�� ����/�÷��̾� ���� �� �� �ϳ��� ��Ƴ���
                        if (battleColleagues.Count == currentActionIndex)
                        {
                            CurrentTrun = BattleTurn.SelectAction;
                        }

                        else
                        {
                            CurrentTrun = BattleTurn.Action;
                        }
                    }
                    break;

                case BattleTurn.BattleEnd:
                    //yield break;
                    break;

                default:
                    Debug.Log("������ �� ���� ���Դϴ�.");
                    break;
            }
        }
    }
}