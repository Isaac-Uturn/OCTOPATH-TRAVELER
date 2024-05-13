using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace ProjectH
{
    [RequireComponent(typeof(PlayableDirector))]
    public class PrewarmDirector : MonoBehaviour
    {
        void OnEnable()
        {
            GetComponent<PlayableDirector>().RebuildGraph();
        }
    }
}