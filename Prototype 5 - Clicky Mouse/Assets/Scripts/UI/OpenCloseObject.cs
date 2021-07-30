using UnityEngine;

namespace ClickyMause
{
    public class OpenCloseObject : MonoBehaviour
    {
        public void ChangeObjectActive()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}