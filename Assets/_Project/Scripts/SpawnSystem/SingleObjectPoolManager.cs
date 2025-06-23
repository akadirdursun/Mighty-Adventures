using MightyAdventures.TargetSystem;
using MightyAdventures.Utilities;
using UnityEngine;

namespace MightyAdventures.SpawnSystem
{
    public class SingleObjectPoolManager : AbstractTargetPoolManager
    {
        [SerializeField] private AbstractTarget target;
        [SerializeField] private int startingPoolSize;

        private ObjectPool<AbstractTarget> _pool;

        protected override void Initialize()
        {
            _pool = new ObjectPool<AbstractTarget>(target, startingPoolSize, OnTargetObjectCreate, OnTargetObjectGet,
                OnTargetObjectReleased);
        }

        public override AbstractTarget GetTarget()
        {
            return _pool.Get();
        }
    }
}