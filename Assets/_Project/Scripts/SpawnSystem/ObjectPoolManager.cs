using System;
using MightyAdventures.Utilities;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MightyAdventures.SpawnSystem
{
    public class ObjectPoolManager : Singleton<ObjectPoolManager>
    {
        [SerializeField] private ObjectPoolInfo<GameObject>[] objectPools;

        private void Initialize()
        {
            foreach (var poolInfo in objectPools)
            {
                poolInfo.InitializePool();
            }
        }

        #region MonoBehaviour Methods

        private void Start()
        {
            Initialize();
        }

        #endregion
        
        #region Structs

        [Serializable]
        private struct ObjectPoolInfo<T> where T : Object
        {
            [SerializeField] private T objectPrefab;
            [SerializeField] private int startingPoolSize;
            [SerializeField, Range(0f, 1f)] private float spawnChance;
            private ObjectPool<T> _pool;

            public float SpawnChance => spawnChance;
            public ObjectPool<T> Pool => _pool;

            public void InitializePool()
            {
                _pool = new ObjectPool<T>(objectPrefab, startingPoolSize);
            }
        }

        #endregion
    }
}