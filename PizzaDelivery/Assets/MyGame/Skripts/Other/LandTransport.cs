using UnityEngine;
using System.Collections;

public class LandTransport : MonoBehaviour, ITransportController
{
    [Header("------ Transport parameters ------")]
    [SerializeField] protected float _transportSpeed = 3f;
    [SerializeField] protected GameObject[] _wheels;
    [SerializeField] protected int _offsetRotationSpeedWheels = 2000;

    private const float WAIT_TIME = 7f;
    protected virtual void Start()
    {
        float rand = Random.Range(5.5f, 7f);
        SetSpeed(rand);
    }
    protected virtual void FixedUpdate()
    {
        Move();
        WheelsRotation();
    }

    public virtual void Move()
    {
        transform.Translate(Vector3.forward * _transportSpeed * Time.fixedDeltaTime);
    }
    public virtual void SetSpeed(float speed)
    {
        _transportSpeed = speed;
    }
    public virtual void WheelsRotation(){
        for (int i = 0; i < _wheels.Length; i++){
            RotateObject(_wheels[i], _transportSpeed, _offsetRotationSpeedWheels);
        }
    }

    protected void RotateObject(GameObject gameObject, float speed, float offsetSpeed)
    {
        gameObject.transform.Rotate(Vector3.right * (speed * offsetSpeed) * Time.fixedDeltaTime);
    }

    protected virtual void OnEnable(){
        StartCoroutine(ResetTransport());
    }
    protected virtual void OnDisable() {
        StopCoroutine(ResetTransport());
    }

    private void SetStartPosition()
    {
        if (transform.position.z >= 10f){
            transform.rotation = Quaternion.Euler(0, 180f, 0);
            return;
        }else{
           transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private IEnumerator ResetTransport()
    {
        yield return new WaitForSeconds(0.5f);
        SetStartPosition();
        yield return new WaitForSeconds(WAIT_TIME);
        gameObject.SetActive(false);
    }
}