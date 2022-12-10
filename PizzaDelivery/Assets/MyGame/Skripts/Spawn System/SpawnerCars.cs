using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnGameObject
{
    public class SpawnerCars : MonoBehaviour
    {
        [Header("--------- Settings Pool Mono ---------")]
        [SerializeField] private int _pooCount = 6;
        [SerializeField] private bool _autoExpand;
        [Space(10)]
        [SerializeField] private LandTransport[] _carsPrefabs;
        [SerializeField] private List<Transform> _positionSpawns;

        private PoolMono<LandTransport> _pool;

        private const float WAIT_TIME = 2f;
        private void Start()
        {
            _pool = new PoolMono<LandTransport>(_carsPrefabs, _pooCount, transform);
            _pool.autoExpand = _autoExpand;
            SpawnCars();
            StartCoroutine(SpawnCarsCoroutine());

        }

        private void OnEnable() => PointCollison.DeletePointsEvent += DeletePoints;
        private void OnDisable() => PointCollison.DeletePointsEvent -= DeletePoints;


        private void SpawnCars()
        {
            foreach (var item in _positionSpawns)
            {
                var cube = _pool.GetFreeElement();
                if (cube == null) break;
                cube.transform.position = item.position;
            }
        }

        private IEnumerator SpawnCarsCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(WAIT_TIME);
                SpawnCars();
            }
        }

        private void DeletePoints(int points)
        {
            _positionSpawns.RemoveRange(0,points); 
        }
    }
}