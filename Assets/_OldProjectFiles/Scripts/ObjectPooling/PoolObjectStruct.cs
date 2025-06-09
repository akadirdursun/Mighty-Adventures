using UnityEngine;
using System.Collections.Generic;

namespace ClickyMause.Targets
{
    [System.Serializable]
    public struct PoolObjectStruct<T>
    {
        [SerializeField] private Queue<T> poolObjects;
        [SerializeField] private T objectPrefab;
        [SerializeField] private int poolStartingSize;

        public Queue<T> PoolObjects { get => poolObjects; set { poolObjects = value; } }

        public T ObjectPrefab { get => objectPrefab; }
        public int PoolSize { get => poolStartingSize; }
    }
}