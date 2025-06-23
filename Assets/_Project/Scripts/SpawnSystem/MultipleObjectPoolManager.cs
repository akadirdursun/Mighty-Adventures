using System;
using System.Linq;
using MightyAdventures.TargetSystem;
using MightyAdventures.Utilities;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MightyAdventures.SpawnSystem
{
    public class ObjectPoolManager : AbstractTargetPoolManager
    {
        [SerializeField] private ObjectPoolInfo<AbstractTarget>[] targetPools;

        private float _totalTargetProbability;

        protected override void Initialize()
        {
            foreach (var poolInfo in targetPools)
            {
                poolInfo.InitializePool(OnTargetObjectCreate, OnTargetObjectGet, OnTargetObjectReleased);
                _totalTargetProbability += poolInfo.SpawnChance;
            }
        }

        public override AbstractTarget GetTarget()
        {
            var currentProbability = 0f;
            var randomProbability = UnityEngine.Random.Range(0f, _totalTargetProbability);
            var selectedTargetPool = targetPools.First(poolInfo =>
            {
                currentProbability += poolInfo.SpawnChance;
                var isSelected = currentProbability >= randomProbability;
                return isSelected;
            });
            return selectedTargetPool.Pool.Get();
        }

        #region Structs

        [Serializable]
        private class ObjectPoolInfo<T> where T : Object
        {
            [SerializeField] private T objectPrefab;
            [SerializeField] private int startingPoolSize;
            [SerializeField, Range(0f, 1f)] private float spawnChance;
            private ObjectPool<T> _pool;

            public float SpawnChance => spawnChance;
            public ObjectPool<T> Pool => _pool;

            public void InitializePool(Action<T, ObjectPool<T>> createAct = null, Action<T> getAct = null,
                Action<T> releaseAct = null)
            {
                _pool = new ObjectPool<T>(objectPrefab, startingPoolSize, createAct, getAct, releaseAct);
            }
        }

        #endregion
    }
}