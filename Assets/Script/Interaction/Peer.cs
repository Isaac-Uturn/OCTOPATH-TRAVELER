using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

//�÷��̾� ĳ������ ����
public class Peer : MonoBehaviour, IInteractable
{
    [SerializeField]
    Canvas canvas;

    [SerializeField]
    Image exclamationMark;

    // Start is called before the first frame update
    void Start()
    {
        //�� �� �����غ���.
        //if (null != exclamationMark
        //    && null != canvas)
        //{
        //    exclamationMark.gameObject.transform.SetParent(canvas.transform, false);
        //}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //�ϴ� �ȵ���ٴϴ� �ɷ� �Ѵ�.
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

        //���ͷ��� ��밡 MainPlayer�� �ƴ�.
        if (null == player)
        {
            Debug.LogError("MainPlyer�� �ƴϸ� ���ᰡ �� �� �����ϴ�!");
            return false;
        }

        player.AddColleague(this);

        //�ٽ� ��ȣ�ۿ���� �ʵ��� ���̾� ����
        gameObject.layer = LayerMask.NameToLayer("Playable");

        return true;
    }
}
