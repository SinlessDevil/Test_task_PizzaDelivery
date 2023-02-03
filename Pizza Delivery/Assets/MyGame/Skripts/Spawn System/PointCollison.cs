using System;
using UnityEngine;

namespace SpawnGameObject
{
    [RequireComponent(typeof (BoxCollider))]
    public class PointCollison : MonoBehaviour
    {
        public static event Action<int> DeletePointsEvent;
        [SerializeField] private int _countPoint;

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.TryGetComponent(out BicycleCharacter player))
            {
                DeletePointsEvent?.Invoke(_countPoint);
                Destroy(this.gameObject);
            }
        }
    }
}