using Assets.Scripts.Controllers;
using Assets.Scripts.Signals;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class CanvasManager : MonoBehaviour
    {
        [SerializeField] private CanvasController _canvasController;

        private void OnEnable()
        {
            CanvasSignal.Instance.onUpdateScore += _canvasController.OnUpdateScore;
            CanvasSignal.Instance.onGetScore += _canvasController.OnGetScore;
        }

        private void OnDisable()
        {
            CanvasSignal.Instance.onUpdateScore -= _canvasController.OnUpdateScore;
            CanvasSignal.Instance.onGetScore -= _canvasController.OnGetScore;
        }
    }
}