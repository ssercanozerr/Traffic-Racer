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
            CanvasSignal.Instance.OnUpdateScore += _canvasController.OnUpdateScore;
            CanvasSignal.Instance.OnGetFinalScore += _canvasController.OnGetFinalScore;
        }

        private void OnDisable()
        {
            CanvasSignal.Instance.OnUpdateScore -= _canvasController.OnUpdateScore;
            CanvasSignal.Instance.OnGetFinalScore -= _canvasController.OnGetFinalScore;
        }
    }
}