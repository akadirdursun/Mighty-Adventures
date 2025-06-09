using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClickyMause
{
    public class PopUp : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(DestroyAfterTime());
        }

        IEnumerator DestroyAfterTime()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                Destroy(gameObject);
            }
        }
    }
}