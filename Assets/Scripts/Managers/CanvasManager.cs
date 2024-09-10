using Assets.Scripts.Controllers;
using Assets.Scripts.Signals;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class CanvasManager : MonoBehaviour
    {
        [SerializeField] private CanvasController _canvasController;

        private void OnEnable()
        {
            CanvasSignal.Instance.onGetScore += _canvasController.OnGetScore;
        }

        private void OnDisable()
        {
            CanvasSignal.Instance.onGetScore -= _canvasController.OnGetScore;
        }
    }
}