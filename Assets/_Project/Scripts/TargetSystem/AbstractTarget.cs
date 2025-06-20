using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MightyAdventures.TargetSystem
{
    public abstract class AbstractTarget : MonoBehaviour
    {
        [SerializeField] private Rigidbody targetRigidbody;

        private const float MinForce = 12f;
        private const float MaxForce = 16f;
        private const float Torque = 12f;

        private Quaternion _defaultRotation;


        public Action OnDisable;

        public virtual void OnHit()
        {
            Disable();
        }

        public void Enable()
        {
            targetRigidbody.isKinematic = false;
        }

        public void Disable()
        {
            targetRigidbody.isKinematic = true;
            targetRigidbody.rotation = _defaultRotation;
            OnDisable?.Invoke();
        }

        public void Throw()
        {
            var force = Random.Range(MinForce, MaxForce);
            targetRigidbody.AddForce(force * Vector3.up, ForceMode.Impulse);
            var torqueForce = Random.Range(-Torque, Torque);
            targetRigidbody.AddTorque(GetRandomTorqueVector() * torqueForce, ForceMode.Impulse);

            Vector3 GetRandomTorqueVector()
            {
                int rn = Random.Range(0, 3);
                switch (rn)
                {
                    case 0:
                        return Vector3.right;
                    case 1:
                        return Vector3.up;
                    default:
                        return Vector3.forward;
                }
            }
        }

        #region MonoBehaviour Methods

        private void Start()
        {
            _defaultRotation = transform.rotation;
        }

        #endregion
    }
}