using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distance;
    [SerializeField] private float _turnRate;
    [SerializeField] private Rigidbody _rigidbody;

    private RotateDirection _rotateDirection;
    private int _turnDirection;

    private void Start()
    {
        _turnRate = Random.Range(-_turnRate, _turnRate);
        _rotateDirection = (RotateDirection)Random.Range(0, 7);
        _turnDirection = Random.Range(0, 1) * 2 - 1;
    }

    private void Update()
    {
        transform.position = transform.localPosition + new Vector3(_speed, 0, 0) * Time.deltaTime;
        RotateCube(_rotateDirection, _turnRate, _turnDirection);
        DestroyCube();
    }

    public void SetStats(float speed, float distance, bool isCollisionsOn)
    {
        _distance = distance;
        _speed = speed;
        _rigidbody.isKinematic = !isCollisionsOn;
    }

    private void DestroyCube()
    {
        if (transform.position.x >= _distance)
            Destroy(gameObject);
    }

    public void DestrotAllCubes()
    {
        foreach (var item in FindObjectsOfType<Cube>())
            Destroy(item.gameObject);
    }

    private void RotateCube(RotateDirection dir, float turnRate, int turnDirection)
    {
        switch (dir)
        {
            case RotateDirection.X:
                transform.Rotate(turnRate * turnDirection * Time.deltaTime, 0f, 0f);
                break;
            case RotateDirection.Y:
                transform.Rotate(0f, turnRate * turnDirection * Time.deltaTime, 0f);
                break;
            case RotateDirection.Z:
                transform.Rotate(0f, 0f, turnRate * turnDirection * Time.deltaTime);
                break;
            case RotateDirection.XY:
                transform.Rotate(turnRate * turnDirection * Time.deltaTime, turnRate * turnDirection * Time.deltaTime, 0f);
                break;
            case RotateDirection.YZ:
                transform.Rotate(0f, turnRate * turnDirection * Time.deltaTime, turnRate * turnDirection * Time.deltaTime);
                break;
            case RotateDirection.XZ:
                transform.Rotate(turnRate * turnDirection * Time.deltaTime, 0f, turnRate * turnDirection * Time.deltaTime);
                break;
            case RotateDirection.XYZ:
                transform.Rotate(turnRate * turnDirection * Time.deltaTime, turnRate * turnDirection * Time.deltaTime, turnRate * turnDirection * Time.deltaTime);
                break;
        }
    }
}

enum RotateDirection
{
    X,
    Y,
    Z,
    XY,
    YZ,
    XZ,
    XYZ
}

