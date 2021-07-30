using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterDelay : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("DisableObject", 1.5f);
    }

    private void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
