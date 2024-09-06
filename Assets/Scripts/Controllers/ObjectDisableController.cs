using Assets.Scripts.Signals;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class ObjectDisableController : MonoBehaviour
    {
        [SerializeField] private int _score;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Car"))
            {
                CanvasSignal.Instance.onUpdateScore?.Invoke(_score);
                collision.gameObject.SetActive(false);
            }
        }
    }
}