using System;
using UnityEngine;

public sealed class BicycleCharacter : LandTransport
{
    public static event Action<Transform, Transform> ProgressBarEvent;
    public static event Action FinishMoveEvent;

    [SerializeField] private Transform _targetPos;
    [SerializeField] private GameObject _pedals;

    private bool isFinish = false;

    private float _minTransportSpeed = 0.01f;
    private float _defaultTransportSpeed = 0.075f;

    private const int _OFFSET_ROTATION_SPEED_PEDALS = 500;

    protected override void Start()
    {
        _offsetRotationSpeedWheels = 2000;
        _transportSpeed = _defaultTransportSpeed;
    }
    protected override void FixedUpdate()
    {
        if(transform.position == _targetPos.position && isFinish == false)
        {
            OnFinishMove();
        }

        if (isFinish == false){
            base.FixedUpdate();
        }

    }

    protected override void OnEnable() => gameObject.SetActive(true);
    protected override void OnDisable() => gameObject.SetActive(false);

    private void OnProgressBarEndGame()
    {
        ProgressBarEvent?.Invoke(this.transform, _targetPos);
    }

    private void OnFinishMove()
    {
        FinishMoveEvent?.Invoke();
        isFinish = true;
    }

    public override void SetSpeed(float offset)
    {
        float newSpeed = _defaultTransportSpeed * offset;
        if (newSpeed <= _minTransportSpeed){
            _transportSpeed = _minTransportSpeed;
            return;
        }
        _transportSpeed = newSpeed;
    }
    public override void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            _targetPos.position, _transportSpeed);
        OnProgressBarEndGame();
    }
    public override void WheelsRotation(){
        for (int i = 0; i < _wheels.Length; i++){
            RotateObject(_wheels[i], _transportSpeed, _offsetRotationSpeedWheels);
        }
    }

    public void PedalsRotation(float speed)
    {
        RotateObject(_pedals, speed, _OFFSET_ROTATION_SPEED_PEDALS);
    }
}