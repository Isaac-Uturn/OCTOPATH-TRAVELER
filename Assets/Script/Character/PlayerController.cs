using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : Character
{
    //public Character prevColleague;

    [SerializeField]
    private float followSpeed;

    float moveX;
    float moveY;

    void Awake()
    {
        gameObject.layer = 7;
    }

    protected override void Start()
    {
        base.Start();
    }

    void LateUpdate()
    {
        //if (currentState == ALLYSTATE.Move)
        //{
        //    Vector3 offset = transform.position - prevColleague.transform.position;
        //    float sqrLen = offset.sqrMagnitude;

        //    if (sqrLen > 0.2f)
        //    {
        //        transform.position = Vector3.Lerp(transform.position, prevColleague.transform.position, followSpeed * Time.deltaTime);
        //    }
        //}
    }

    private void Update()
    {
        //currentState = prevColleague.GetState();

        //switch (currentState)
        //{
        //    case ALLYSTATE.FowardIdle:
        //        animator.enabled = false;
        //        renderer.sprite = sprites[1];
        //        break;
        //    case ALLYSTATE.BackIdle:
        //        animator.enabled = false;
        //        renderer.sprite = sprites[0];
        //        break;
        //    case ALLYSTATE.LeftIdle:
        //        animator.enabled = false;
        //        renderer.sprite = sprites[2];
        //        break;
        //    case ALLYSTATE.RightIdle:
        //        animator.enabled = false;
        //        renderer.sprite = sprites[3];
        //        break;
        //    case ALLYSTATE.Move:
        //        animator.enabled = true;
        //        moveX = prevColleague.GetMoveX();
        //        moveY = prevColleague.GetMoveY();

        //        animator.SetFloat("DirectX", moveX);
        //        animator.SetFloat("DirectY", moveY);
        //        break;
        //    case ALLYSTATE.Combat:
        //        animator.enabled = true;
        //        animator.SetBool("isCombat", true);
        //        break;
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ("Player" == collision.gameObject.tag)
        {
            collider.isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ("Player" != other.gameObject.tag)
        {
            collider.isTrigger = false;
        }
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    if ("Player" == collision.gameObject.tag)
    //    {
    //        colleagueCollider.isTrigger = false;
    //    }
    //}
}


