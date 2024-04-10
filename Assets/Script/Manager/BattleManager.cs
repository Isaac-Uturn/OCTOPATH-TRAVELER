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

//배틀시작
//명령 선택
//플레이어가 몬스터 공격
//몬스터가 플레이어 공격
//죽었다면 비활성화 혹은 삭제
//몬스터나 플레이어 전멸 시 게임 끝
//다시 명령 선택
//플레이어가 몬스터 공격
//몬스터가 플레이어 공격
//몬스터나 플레이어 전멸 시 게임 끝
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
//    // 씬 매니저의 sceneLoaded에 체인을 건다.
//    SceneManager.sceneLoaded += OnSceneLoaded;
//}

//// 체인을 걸어서 이 함수는 매 씬마다 호출된다.
//void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//{
//    //배틀씬일 경우 하이어라키 창에서 위치를 찾아 대입하는 방법이 있음
//    if (SceneManager.GetActiveScene().name == "Battle")
//    {
//        gameObject.transform.position = GameObject.Find("Point").transform.position;
//        gameObject.GetComponent<PlayerController>().enabled = false;
//    }
//}