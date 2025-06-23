using MightyAdventures.TargetSystem;
using MightyAdventures.Utilities;
using UnityEngine;

namespace MightyAdventures.SpawnSystem
{
    public abstract class AbstractTargetPoolManager : MonoBehaviour
    {
        protected abstract void Initialize();
        
        public abstract AbstractTarget GetTarget();
        
        #region Pool Methods

        protected void OnTargetObjectCreate(AbstractTarget obj, ObjectPool<AbstractTarget> objPool)
        {
            obj.gameObject.SetActive(false);
            obj.OnDisable += OnTargetDisabled;

            void OnTargetDisabled()
            {
                objPool.Release(obj);
            }
        }

        protected void OnTargetObjectGet(AbstractTarget obj)
        {
            obj.gameObject.SetActive(true);
        }

        protected void OnTargetObjectReleased(AbstractTarget obj)
        {
            obj.gameObject.SetActive(false);
        }

        #endregion
        
        #region MonoBehaviour Methods

        private void Start()
        {
            Initialize();
        }

        #endregion
        
    }
}