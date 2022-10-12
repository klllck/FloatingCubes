using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField] private Cube _cube;
    [SerializeField] private float _spawnTime;
    [SerializeField] private float _spawnRange;

    [Header("Cube Settings")]
    [SerializeField] private float _cubeSpeed;
    [SerializeField] private float _cubeMoveDistance;

    [Header("UI Components")]
    [SerializeField] private TMP_InputField _spawnTimeInput;
    [SerializeField] private TMP_InputField _spawnRangeInput;
    [SerializeField] private TMP_InputField _cubeSpeedInput;
    [SerializeField] private TMP_InputField _cubeMoveDistanceInput;
    [SerializeField] private Toggle _collisionsToggle;

    private float _elapsedTime;

    private void Start()
    {
        _elapsedTime = 0f;
        _spawnTimeInput.text = "1000";
        _spawnRangeInput.text = "2";
        _cubeSpeedInput.text = "3";
        _cubeMoveDistanceInput.text = "20";

        SetValues();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > _spawnTime)
        {
            _elapsedTime = 0f;
            SpawnCube();
        }
    }

    private void SpawnCube()
    {
        var cube = Instantiate(_cube);
        cube.transform.SetPositionAndRotation(transform.position + new Vector3(0, Random.Range(-_spawnRange, _spawnRange), Random.Range(-_spawnRange, _spawnRange)), 
            Quaternion.identity);
    }

    public void SetValues()
    {
        if (!string.IsNullOrEmpty(_spawnTimeInput.text))
            _spawnTime = float.Parse(_spawnTimeInput.text, NumberStyles.Any, CultureInfo.CurrentCulture) / 1000f;
        if (!string.IsNullOrEmpty(_spawnRangeInput.text))
            _spawnRange = float.Parse(_spawnRangeInput.text, NumberStyles.Any, CultureInfo.CurrentCulture);
        if (!string.IsNullOrEmpty(_cubeSpeedInput.text))
            _cubeSpeed = float.Parse(_cubeSpeedInput.text, NumberStyles.Any, CultureInfo.CurrentCulture);
        if (!string.IsNullOrEmpty(_cubeMoveDistanceInput.text))
            _cubeMoveDistance = float.Parse(_cubeMoveDistanceInput.text, NumberStyles.Any, CultureInfo.CurrentCulture);

        _cube.SetStats(_cubeSpeed, _cubeMoveDistance, _collisionsToggle.isOn);
    }
}
