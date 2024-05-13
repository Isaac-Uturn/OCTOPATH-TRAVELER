using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

//게임 상 하나만 존재하며 유일하게 조작이 가능한 캐릭터.
//TODO: 다른 플레이어블 캐릭터도 메인 캐릭터로 변경 가능해야 함.
public class MainPlayer : MonoBehaviour
{
    protected CharcterMoveState currentState;

    PlayerController _playerController;

    Vector2 _movement;
    float _offset = 0.5f;

    float _basicSpeed = 0;

    private readonly string _horizontal = "Horizontal";
    private readonly string _vertical = "Vertical";

    private readonly string _lastHorizontal = "LastHorizontal";
    private readonly string _lastHVertical = "LastVertical";
    
    [SerializeField]
    private float walkSpeed = 1.5f;
    [SerializeField]
    private float runSpeed = 3.5f;

    List<Peer> _colleagues = new List<Peer>(5);

    private Animator _animator;
    private SpriteRenderer _renderer;
    private Rigidbody _rigidBody;

    void Awake()
    {
        _basicSpeed = walkSpeed;
        currentState = CharcterMoveState.ForwardIdle;
    }

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _playerController.PressSprint += OnSprint;
        _playerController.ReleaseSprint += OnWalk;

        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _rigidBody = GetComponent<Rigidbody>();

        //animator.enabled = false;
        //collider.size = new Vector3(0.5f, 0.66f, 0.5f);
    }

    //약점
    //고유 액션
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

        float speed = _movement.x * _offset;

        Debug.Log("Speed :" + speed);

        _animator.SetFloat(_horizontal, _movement.x * _offset);
        _animator.SetFloat(_vertical, _movement.y * _offset);

        Vector3 Dir = new Vector3(_movement.x, 0, _movement.y);
        _rigidBody.MovePosition(transform.position + (Dir * _basicSpeed * Time.deltaTime));

        if (0 < _movement.x)
        {
            _renderer.flipX = true;
        }

        else if (0 > _movement.x)
        {
            _renderer.flipX = false;
        }

        if (_movement != Vector2.zero)
        {
            _animator.SetFloat(_lastHorizontal, _movement.x);
            _animator.SetFloat(_lastHVertical, _movement.y);
        }
    }

    void OnSprint()
    {
        _offset = 1.0f;
        _basicSpeed = runSpeed;
    }

    void OnWalk()
    {
        _offset = 0.5f;
        _basicSpeed = walkSpeed;
    }

    public void AddColleague(Peer colleague)
    {
        _colleagues.Add(colleague);

        //if (1 == _colleagues.Count)
        //{
        //    character.charcterTransform = transform;
        //}

        Debug.Log("동료 추가.");
    }
}
