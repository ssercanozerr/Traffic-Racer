using Assets.Scripts.Signals;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class ObjectDisableController : MonoBehaviour
    {
        [SerializeField] private int _score;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Car"))
            {
                CanvasSignal.Instance.OnUpdateScore?.Invoke(_score);
                collision.gameObject.SetActive(false);
            }
        }
    }
}