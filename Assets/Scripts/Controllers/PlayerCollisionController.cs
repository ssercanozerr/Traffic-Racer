using Assets.Scripts.Signals;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class PlayerCollisionController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Car"))
            {
                GameSignal.Instance.onGameOver?.Invoke();
            }
        }
    }
}