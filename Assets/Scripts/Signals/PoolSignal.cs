using Assets.Scripts.Enums;
using System;
using UnityEngine;

namespace Assets.Scripts.Signals
{
    public class PoolSignal : MonoBehaviour
    {
        public static PoolSignal Instance;

        public Func<EntityTypes, GameObject> onGetObjectFromPool;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }
    }
}