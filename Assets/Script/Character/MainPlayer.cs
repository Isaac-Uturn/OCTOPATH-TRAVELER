using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

//���� �� �ϳ��� �����ϸ� �����ϰ� ������ ������ ĳ����.
//TODO: �ٸ� �÷��̾�� ĳ���͵� ���� ĳ���ͷ� ���� �����ؾ� ��.
public class MainPlayer : PlayableCharacter
{
    protected CharcterMoveState currentState;

    PlayerController _playerController;

    Vector2 _movement;
    float _offset;

    float _basicSpeed = 0;

    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";

    private const string _lastHorizontal = "LastHorizontal";
    private const string _lastHVertical = "LastVertical";
    
    [SerializeField]
    private float walkSpeed = 1.5f;
    [SerializeField]
    private float runSpeed = 3.5f;

    float value = 0.5f;

    int battleRandom;
    int randomValue;

    void Awake()
    {
        //gameObject.layer = 6;
        //alliance.Add(this);

        _basicSpeed = walkSpeed;
        currentState = CharcterMoveState.ForwardIdle;
    }

    protected override void Start()
    {
        base.Start();

        _playerController = GetComponent<PlayerController>();
        _playerController.PressSprint += OnSprint;
        _playerController.ReleaseSprint += OnWalk;

        //animator.enabled = false;
        //collider.size = new Vector3(0.5f, 0.66f, 0.5f);
    }

    //����
    //���� �׼�
    public CharcterMoveState GetState()
    {
        return currentState;
    }

    private void FixedUpdate()
    {
        MoveToPlayer();
    }

    void MoveToPlayer()
    {
        _movement = _playerController.inputVector;
        _offset = value;

        float speed = _movement.x * _offset;

        Debug.Log("Speed :" + speed);

        animator.SetFloat(_horizontal, _movement.x * _offset);
        animator.SetFloat(_vertical, _movement.y * _offset);

        Vector3 Dir = new Vector3(_movement.x, 0, _movement.y);
        rigidBody.MovePosition(transform.position + (Dir * _basicSpeed * Time.deltaTime));

        if (0 < _movement.x)
        {
            renderer.flipX = true;
        }

        else if (0 > _movement.x)
        {
            renderer.flipX = false;
        }

        if (_movement != Vector2.zero)
        {
            animator.SetFloat(_lastHorizontal, _movement.x);
            animator.SetFloat(_lastHVertical, _movement.y);
        }
    }

    void OnSprint()
    {
        value = 1.0f;
        _basicSpeed = runSpeed;
    }

    void OnWalk()
    {
        value = 0.5f;
        _basicSpeed = walkSpeed;
    }

    void TransAnimation()
    {
        if (Input.GetKeyUp(KeyCode.W)
            || Input.GetKeyUp(KeyCode.UpArrow))
        {
            currentState = CharcterMoveState.BackIdle;
        }

        else if (Input.GetKeyUp(KeyCode.S)
            || Input.GetKeyUp(KeyCode.DownArrow))
        {
            currentState = CharcterMoveState.ForwardIdle;
        }

        else if (Input.GetKeyUp(KeyCode.A)
            || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            currentState = CharcterMoveState.LeftIdle;
        }

        else if (Input.GetKeyUp(KeyCode.D)
            || Input.GetKeyUp(KeyCode.RightArrow))
        {
            currentState = CharcterMoveState.RightIdle;
        }
    }

    bool isDown = false;

    void ChangeBattleSnece()
    {
        if (Input.GetKeyDown(KeyCode.B) && false == isDown)
        {
            isDown = true;

            randomValue = Random.Range(1000, 2500);
            //SceneManager.LoadScene("Battle");

            currentState = CharcterMoveState.Combat;
        }

        if (battleRandom == randomValue)
        {

        }
    }

    //public List<Character> GetAllianceList()
    //{
    //    return alliance;
    //}

    void CreateColleague()
    {
        //if (5 == alliance.Count)
        //{
        //    return;
        //}

        //GameObject instante = Instantiate(prefab[characterIndex], null);
        //DontDestroyOnLoad(instante);
        //PlayerController colleague = instante.GetComponent<PlayerController>();
        //colleague.transform.position = alliance[alliance.Count - 1].transform.position;
        //colleague.transform.position += new Vector3(0.0f, 1.0f, 0.0f);

        //if (1 > characterIndex)
        //{
        //    ++characterIndex;
        //}

        //switch (alliance.Count)
        //{
        //    case 1:
        //        colleague.prevColleague = this;
        //        break;

        //    case 2:
        //        colleague.prevColleague = alliance[1];
        //        break;

        //    case 3:
        //        colleague.prevColleague = alliance[2];
        //        break;

        //    case 4:
        //        colleague.prevColleague = alliance[3];
        //        break;

        //    case 5:
        //        colleague.prevColleague = alliance[4];
        //        break;
        //}

        //alliance.Add(colleague);
    }

    void OnEnable()
    {
        // �� �Ŵ����� sceneLoaded�� ü���� �Ǵ�.
        //SceneManager.sceneLoaded += OnSceneLoaded;

    }

    //// ü���� �ɾ �� �Լ��� �� ������ ȣ��ȴ�.
    //void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    //{
    //    //��Ʋ���� ��� ���̾��Ű â���� ��ġ�� ã�� �����ϴ� ����� ����
    //    if (SceneManager.GetActiveScene().name == "Battle")
    //    {
    //        gameObject.transform.position = GameObject.Find("Point").transform.position;
    //        gameObject.GetComponent<Player>().enabled = false;
    //    }
    //}
}
