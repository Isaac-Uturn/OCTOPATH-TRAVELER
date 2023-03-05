using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Colleague : Alliance
{
    public Alliance prevColleague;

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
        if (currentState == ALLYSTATE.Move)
        {
            Vector3 offset = transform.position - prevColleague.transform.position;
            float sqrLen = offset.sqrMagnitude;

            if (sqrLen > 0.2f)
            {
                transform.position = Vector3.Lerp(transform.position, prevColleague.transform.position, followSpeed * Time.deltaTime);
            }
        }
    }

    private void Update()
    {
        currentState = prevColleague.GetState();

        switch (currentState)
        {
            case ALLYSTATE.FowardIdle:
                aAnim.enabled = false;
                aRenderer.sprite = sprites[1];
                break;
            case ALLYSTATE.BackIdle:
                aAnim.enabled = false;
                aRenderer.sprite = sprites[0];
                break;
            case ALLYSTATE.LeftIdle:
                aAnim.enabled = false;
                aRenderer.sprite = sprites[2];
                break;
            case ALLYSTATE.RightIdle:
                aAnim.enabled = false;
                aRenderer.sprite = sprites[3];
                break;
            case ALLYSTATE.Move:
                aAnim.enabled = true;
                moveX = prevColleague.GetMoveX();
                moveY = prevColleague.GetMoveY();

                aAnim.SetFloat("DirectX", moveX);
                aAnim.SetFloat("DirectY", moveY);
                break;
            case ALLYSTATE.Combat:
                aAnim.enabled = true;
                aAnim.SetBool("isCombat", true);
                break;
        }
    }

    public override float GetMoveX()
    {
        return moveX;
    }

    public override float GetMoveY()
    {
        return moveY;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ("Player" == collision.gameObject.tag)
        {
            aCollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ("Player" != other.gameObject.tag)
        {
            aCollider.isTrigger = false;
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


