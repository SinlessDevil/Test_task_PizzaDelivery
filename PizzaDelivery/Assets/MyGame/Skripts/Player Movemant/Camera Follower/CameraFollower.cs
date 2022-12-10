using UnityEngine;

namespace SmoothCamera
{
    public class CameraFollower : MonoBehaviour, IMovable
    {
        [SerializeField] private Transform _targetPos;
        [SerializeField] private float _smoothing = 1f;

        private Vector3 _offset;

        private void Start()
        {
            _offset = this.gameObject.transform.position;
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void Move()
        {
            FollowTarget();
        }

        private void FollowTarget()
        {
            var nextPosition = Vector3.Lerp(transform.position, 
                _targetPos.position + _offset, Time.fixedDeltaTime * _smoothing);

            transform.position = nextPosition;
        }
    }
}
