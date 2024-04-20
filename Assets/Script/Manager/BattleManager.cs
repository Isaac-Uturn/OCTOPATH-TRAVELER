using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BattleManager�� Battle ������ ������.
public class BattleManager : MonoBehaviour, IBattleMediator
{
    public BattleTurn currentTrun = BattleTurn.None;

    [SerializeField]
    BattleUI BattleUI;

    //IBattleColleague�� �����ص� �� �� ����.
    List<IBattleColleague> battleColleagues = new List<IBattleColleague>();

    int currentActionIndex = 0;

    public void Initialized()
    {
        currentTrun = BattleTurn.SelectAction;
        BattleUI.currentBattleStateText.text = currentTrun.ToString();
    }

    //�� ��ȯ �� ���� �� ĳ���͵��� �ʱ�ȭ�Ѵ�.
    public void AddBattleColleague(IBattleColleague colleague)
    {
        battleColleagues.Add(colleague);
    }

    public IEnumerator Battle()
    {
        while (true)
        {
            switch (currentTrun)
            {
                //��� �÷��̾�� ĳ���Ͱ� �׼��� ����.
                //�� ĳ���͵鵵 AI�� ���� �׼� ����
                case BattleTurn.SelectAction:
                    {
                        yield return BattleUI.BattleUIEnable();

                        currentTrun = BattleTurn.Action;
                        BattleUI.currentBattleStateText.text = currentTrun.ToString();
                    }
                    break;

                //�ӵ��� ���� �Ӽ��� ���� �� ĳ���� �׼�
                //if: �׼��� ĳ���Ͱ� ���ٸ� �ٽ� Select.
                case BattleTurn.Action:
                    {
                        yield return battleColleagues[currentActionIndex].Notify();
                        currentTrun = BattleTurn.ActionEnd;

                        BattleUI.currentBattleStateText.text = currentTrun.ToString();
                    }
                    break;

                //�׼� ���� ó��
                case BattleTurn.ActionEnd:
                    {
                        ++currentActionIndex;
                        BattleUI.currentBattleStateText.text = currentTrun.ToString();

                        //�� ����/�÷��̾� ���� �� �� �ϳ��� ��Ƴ���
                        if (battleColleagues.Count == currentActionIndex)
                        {
                            currentTrun = BattleTurn.SelectAction;
                            BattleUI.currentBattleStateText.text = currentTrun.ToString();
                        }
                        else
                        {
                            currentTrun = BattleTurn.Action;
                            BattleUI.currentBattleStateText.text = currentTrun.ToString();
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