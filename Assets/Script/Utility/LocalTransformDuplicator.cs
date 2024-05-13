using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectH
{
    //활성화 시 주어진 트랜스폼 위치, 회전 및 스케일을 복제.
    public class LocalTransformDuplicator : MonoBehaviour
    {
        public Transform targetTrasnform;

        private void OnEnable()
        {
            transform.localScale = targetTrasnform.localScale;
            transform.localRotation = targetTrasnform.localRotation;
            transform.localPosition = targetTrasnform.localPosition;
        }
    }
}