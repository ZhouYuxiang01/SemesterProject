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
        /// <summary>
        /// We return true on Decide
        /// </summary>
        /// <returns></returns>
        public override bool Decide()
        {
            if (Input.GetKeyUp(KeyCode.Q))
            {
                return true;
            }
            return false;
        }
    }
}