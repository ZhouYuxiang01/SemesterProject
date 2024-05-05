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
        public GameObject targetObject; // 使用GameObject来代替Transform
        public float maxDistance = 5f;
        public AudioClip SoundEffect;
        public AudioSource AudioSource;

        public override bool Decide()
        {
            if (Input.GetKeyUp(KeyCode.Q) && targetObject != null && Vector3.Distance(transform.position, targetObject.transform.position) <= maxDistance)
            {
                PlaySoundEffect();
                return true;
            }
            return false;
        }

        protected void PlaySoundEffect()
        {
            if (AudioSource != null && SoundEffect != null)
            {
                AudioSource.PlayOneShot(SoundEffect);
            }
        }
    }
}