using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.TopDownEngine
{
    /// <summary>
    /// This decision will return true when entering the state this Decision is on.
    /// </summary>
    [AddComponentMenu("TopDown Engine/Character/AI/Decisions/PressQ")]
    public class PressQ : AIDecision
    {
        public Transform targetObject;
        public float maxDistance = 5f;
        public override bool Decide()
        {
            if (Input.GetKeyUp(KeyCode.Q) && Vector3.Distance(transform.position, targetObject.position) <= maxDistance)
            {
                return true;
            }
            return false;
        }
    }
}