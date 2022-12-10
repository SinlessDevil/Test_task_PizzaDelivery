using UnityEngine;

public class ShootPizza : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Transform _targetPoint;

    [SerializeField] private GameObject _pizzaPrefab;

    private float _anglerInDegrees = 60;
    private float g = Physics.gravity.y;
    private void Update()
    {
       // _shootPoint.localEulerAngles = new Vector3(-_anglerInDegrees, 0f, 0f);
    }

    private void OnEnable()
    {
        BicycleCharacter.FinishMoveEvent += Shoot;
    }

    private void OnDisable()
    {
        BicycleCharacter.FinishMoveEvent -= Shoot;
    }

    private void Shoot()
    {
        Vector3 fromTo = _targetPoint.position - transform.position;
        Vector3 fromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);

        transform.rotation = Quaternion.LookRotation(fromToXZ, Vector3.up);

        float x = fromToXZ.magnitude;
        float y = fromTo.y;

        float AngleInRadians = _anglerInDegrees * Mathf.PI / 180;

        float v2 = (g * x * x) / (2 * (y - Mathf.Tan(AngleInRadians) * x) * Mathf.Pow(Mathf.Cos(AngleInRadians), 2));
        float v = Mathf.Sqrt(Mathf.Abs(v2)) - 1f;

        GameObject newBullet = Instantiate(_pizzaPrefab, _shootPoint.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = _shootPoint.forward * v;
    }
}
