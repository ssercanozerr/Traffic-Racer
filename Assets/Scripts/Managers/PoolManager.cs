using Assets.Scripts.Signals;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] PoolController _poolController;

    private void OnEnable()
    {
        PoolSignal.Instance.onGetObjectFromPool += _poolController.OnGetObjectFromPool;
    }

    private void OnDisable()
    {
        PoolSignal.Instance.onGetObjectFromPool -= _poolController.OnGetObjectFromPool;
    }
}
