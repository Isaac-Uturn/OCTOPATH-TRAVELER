using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectH
{
    //부모 객체를 가질 때 유용. (렌더러 없이)
    //OnBecameVisible 호출을 버블업할 수 있음.
    //자식이 표시될 때 알림 받기.
    public class VisibleBubbleUp : MonoBehaviour
    {
        public System.Action<VisibleBubbleUp> objectBecameVisible;

        private void OnBecameVisible()
        {
            objectBecameVisible(this);
        }
    }
}