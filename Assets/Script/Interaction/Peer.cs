using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

//플레이어 캐릭터의 동료
public class Peer : MonoBehaviour, IInteractable
{
    [SerializeField]
    Canvas canvas;

    [SerializeField]
    Image exclamationMark;

    // Start is called before the first frame update
    void Start()
    {
        //좀 더 생각해보자.
        //if (null != exclamationMark
        //    && null != canvas)
        //{
        //    exclamationMark.gameObject.transform.SetParent(canvas.transform, false);
        //}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //일단 안따라다니는 걸로 한다.
        //if (charcterTransform != null)
        //{
        //    Vector3 offset = transform.position - charcterTransform.transform.position;
        //    float sqrLen = offset.sqrMagnitude;

        //    if (sqrLen > 0.5f)
        //    {
        //        transform.position = Vector3.Lerp(transform.position, charcterTransform.transform.position, 2.0f * Time.deltaTime);
        //    }
        //}
    }

    public bool Interact(Interactor interactor)
    {
        MainPlayer player = interactor.GetComponent<MainPlayer>();

        //인터렉션 상대가 MainPlayer가 아님.
        if (null == player)
        {
            Debug.LogError("MainPlyer가 아니면 동료가 될 수 없습니다!");
            return false;
        }

        player.AddColleague(this);

        //다시 상호작용되지 않도록 레이어 변경
        gameObject.layer = LayerMask.NameToLayer("Playable");

        return true;
    }
}
