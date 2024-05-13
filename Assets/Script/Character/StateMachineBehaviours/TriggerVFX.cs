using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectH
{
    public class TriggerVFX : StateMachineBehaviour
    {
        public string vfxName;
        public Vector3 offset = Vector3.zero;
        public bool attachToParent = false;
        public float startDelay = 0;
        public bool OnEnter = true;
        public bool OnExit = false;
        int vfxId = 0;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (true == OnEnter)
            {
                Trigger(animator.transform);
            }
        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (true == OnExit)
            {
                Trigger(animator.transform);
            }
        }

        void Trigger(Transform transform)
        {
            bool flip = false;
            SpriteRenderer spriteRender = transform.GetComponent<SpriteRenderer>();

            if (null != spriteRender)
            {
                flip = spriteRender.flipX;
            }

            VFXController.Instance.Trigger(vfxName, offset, startDelay, flip, attachToParent ? transform : null);
        }
    }
}