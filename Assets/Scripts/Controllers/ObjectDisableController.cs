using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class ObjectDisableController : MonoBehaviour
    {
        private string _tagName = "Car";

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(_tagName))
            {
                collision.gameObject.SetActive(false);
            }
        }
    }
}