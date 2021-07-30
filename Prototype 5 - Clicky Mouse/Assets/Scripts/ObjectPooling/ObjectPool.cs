using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClickyMause.Targets
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private PoolObjectStruct<GameObject>[] targetPools;
        [SerializeField] private PoolObjectStruct<ParticleSystem>[] particlePools;

        private void Awake()
        {
            InitializePools();
        }

        private void InitializePools()
        {
            for (int i = 0; i < targetPools.Length; i++)
            {
                targetPools[i].PoolObjects = new Queue<GameObject>();
                for (int j = 0; j < targetPools[i].PoolSize; j++)
                {
                    var obj = Instantiate(targetPools[i].ObjectPrefab, transform);
                    targetPools[i].PoolObjects.Enqueue(obj);
                    obj.GetComponent<AbstractTarget>().ParticlePool = this;
                    obj.SetActive(false);
                }
            }

            for (int i = 0; i < particlePools.Length; i++)
            {
                particlePools[i].PoolObjects = new Queue<ParticleSystem>();
                for (int j = 0; j < particlePools[i].PoolSize; j++)
                {
                    var obj = Instantiate(particlePools[i].ObjectPrefab, transform);
                    particlePools[i].PoolObjects.Enqueue(obj);
                    obj.gameObject.SetActive(false);
                }
            }
        }        

        public GameObject GetRandomPoolObject()
        {
            int index = Random.Range(0, targetPools.Length);
            if (targetPools[index].PoolObjects.Peek().activeInHierarchy)
            {
                GameObject newObj = Instantiate(targetPools[index].ObjectPrefab, transform);
                targetPools[index].PoolObjects.Enqueue(newObj);
                newObj.GetComponent<AbstractTarget>().ParticlePool = this;
                newObj.SetActive(false);
                return newObj;
            }
            GameObject obj = targetPools[index].PoolObjects.Dequeue();
            targetPools[index].PoolObjects.Enqueue(obj);
            return obj;
        }

        public ParticleSystem GetParticle(ParticleColor color) 
        {
            int index = (int)color;
            if (particlePools[index].PoolObjects.Peek().gameObject.activeInHierarchy)
            {
                var newObj = Instantiate(particlePools[index].ObjectPrefab, transform);
                particlePools[index].PoolObjects.Enqueue(newObj);
                newObj.gameObject.SetActive(false);
                return newObj;
            }
            var obj = particlePools[index].PoolObjects.Dequeue();
            particlePools[index].PoolObjects.Enqueue(obj);
            return obj;
        }
    }

    public enum ParticleColor { Black, Blue, Brown, Green, Grey, Orange, Pink, Purple, Red, Yellow}
}