using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Colleague : Alliance
{
    public Alliance prevColleague;

    [SerializeField]
    private float followSpeed;

    Animator colleagueAnim;
    SpriteRenderer colleagueRenderer;
    BoxCollider colleagueCollider;
    Rigidbody colleagueRigid;

    float moveX;
    float moveY;

    private void Awake()
    {
        colleagueAnim = GetComponent<Animator>();
        colleagueRenderer = GetComponent<SpriteRenderer>();
        colleagueCollider = gameObject.AddComponent<BoxCollider>();
        colleagueCollider.size = new Vector3(0.5f, 0.66f, 0.5f);
        //colleagueRigid = gameObject.AddComponent<Rigidbody>();
        //colleagueRigid.freezeRotation = true;
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
                colleagueAnim.enabled = false;
                colleagueRenderer.sprite = sprites[1];
                break;
            case ALLYSTATE.BackIdle:
                colleagueAnim.enabled = false;
                colleagueRenderer.sprite = sprites[0];
                break;
            case ALLYSTATE.LeftIdle:
                colleagueAnim.enabled = false;
                colleagueRenderer.sprite = sprites[2];
                break;
            case ALLYSTATE.RightIdle:
                colleagueAnim.enabled = false;
                colleagueRenderer.sprite = sprites[3];
                break;
            case ALLYSTATE.Move:
                colleagueAnim.enabled = true;
                moveX = prevColleague.GetMoveX();
                moveY = prevColleague.GetMoveY();

                colleagueAnim.SetFloat("DirectX", moveX);
                colleagueAnim.SetFloat("DirectY", moveY);
                break;
            case ALLYSTATE.Combat:

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
            colleagueCollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ("Player" != other.gameObject.tag)
        {
            colleagueCollider.isTrigger = false;
        }
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    //if ("Player" == collision.gameObject.tag)
    //    //{
    //    //    colleagueCollider.isTrigger = false;
    //    //}
    //}
}


