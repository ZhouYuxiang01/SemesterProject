using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

namespace MoreMountains.TopDownEngine
{
    //[AddComponentMenu("TopDown Engine/Character/AI/Actions/AIActionMoveTowardsTarget3D")]
    //[RequireComponent(typeof(CharacterMovement))]
    public class Follow : AIAction
    {
        public float MinimumDistance = 1f;
        public Transform targetObject; // The target object to follow

        protected Vector3 _directionToTarget;
        protected CharacterMovement _characterMovement;
        protected Vector2 _movementVector;

        public override void Initialization()
        {
            if (!ShouldInitialize) return;
            base.Initialization();
            _characterMovement = this.gameObject.GetComponentInParent<Character>()?.FindAbility<CharacterMovement>();
        }

        public override void PerformAction()
        {
            Move();
        }

        protected virtual void Move()
        {
            if (targetObject == null) // If no target is assigned, do nothing
            {
                return;
            }

            _directionToTarget = targetObject.position - this.transform.position;
            _movementVector.x = _directionToTarget.x;
            _movementVector.y = _directionToTarget.z;
            _characterMovement.SetMovement(_movementVector);

            if (Mathf.Abs(this.transform.position.x - targetObject.position.x) < MinimumDistance)
            {
                _characterMovement.SetHorizontalMovement(0f);
            }

            if (Mathf.Abs(this.transform.position.z - targetObject.position.z) < MinimumDistance)
            {
                _characterMovement.SetVerticalMovement(0f);
            }
        }

        public override void OnExitState()
        {
            base.OnExitState();
            _characterMovement?.SetHorizontalMovement(0f);
            _characterMovement?.SetVerticalMovement(0f);
        }
    }
}
