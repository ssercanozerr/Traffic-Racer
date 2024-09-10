using Assets.Scripts.Signals;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class PlayerCollisionController : MonoBehaviour
    {
        private string _tagName = "Car";

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(_tagName))
            {
                GameSignal.Instance.onGameOver?.Invoke();
            }
        }
    }
}