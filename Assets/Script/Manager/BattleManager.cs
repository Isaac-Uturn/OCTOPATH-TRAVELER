using System.Collections.Generic;
using UnityEngine;

public enum BattleTurn
{
    None,
    SelectAction,
    PlayerAttack,
    EnemyAttack,
    DamageCount,
    BattleEnd
}

//��Ʋ����
//��� ����
//�÷��̾ ���� ����
//���Ͱ� �÷��̾� ����
//�׾��ٸ� ��Ȱ��ȭ Ȥ�� ����
//���ͳ� �÷��̾� ���� �� ���� ��
//�ٽ� ��� ����
//�÷��̾ ���� ����
//���Ͱ� �÷��̾� ����
//���ͳ� �÷��̾� ���� �� ���� ��
public class BattleManager : MonoBehaviour, IBattleMediator
{
    public BattleTurn currentTrun = BattleTurn.None;

    Queue<GameObject> actionQueue = new Queue<GameObject>();

    [SerializeField]
    Transform[] leftTrasforms = new Transform[5];
    [SerializeField]
    Transform[] rightTrasforms = new Transform[5];

    List<GameObject> characterList = new List<GameObject>();
    List<GameObject> enemyList = new List<GameObject>();

    void Start()
    {
    }

    public void AddCharacter(GameObject character)
    {
        characterList.Add(character);
    }

    public void AddEnemy(GameObject enemy)
    {
        enemyList.Add(enemy);
    }

    public void Battle()
    {
        float striking = 0.0f;

        switch (currentTrun)
        {
            case BattleTurn.None:
                {
                    CombatComponent component = characterList[0].GetComponent<CombatComponent>();
                    striking = component.Attack(enemyList[0]);

                    currentTrun = BattleTurn.SelectAction;
                }
                break;
            case BattleTurn.SelectAction:
                {
                    CombatComponent component = characterList[0].GetComponent<CombatComponent>();
                    component.AttackComback(rightTrasforms[3]);

                    currentTrun = BattleTurn.PlayerAttack;
                }
                break;
            case BattleTurn.PlayerAttack:
                {

                }
                break;
            case BattleTurn.EnemyAttack:
                break;
            case BattleTurn.DamageCount:
                break;
            case BattleTurn.BattleEnd:
                break;
            default:
                break;
        }
    }
}

//void OnEnable()
//{
//    // �� �Ŵ����� sceneLoaded�� ü���� �Ǵ�.
//    SceneManager.sceneLoaded += OnSceneLoaded;
//}

//// ü���� �ɾ �� �Լ��� �� ������ ȣ��ȴ�.
//void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//{
//    //��Ʋ���� ��� ���̾��Ű â���� ��ġ�� ã�� �����ϴ� ����� ����
//    if (SceneManager.GetActiveScene().name == "Battle")
//    {
//        gameObject.transform.position = GameObject.Find("Point").transform.position;
//        gameObject.GetComponent<PlayerController>().enabled = false;
//    }
//}