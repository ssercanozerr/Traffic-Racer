using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class ObjectDisableController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Car"))
            {
                collision.gameObject.SetActive(false);
            }
        }
    }
}