using UnityEngine;

public class SpinPulseTransforms : MonoBehaviour
{
    [SerializeField] private Transform[] _spinLights;
    [SerializeField] private float[] _spinSpeeds; // degrees per second
    [SerializeField] private float _minSpinSpeed = 270f, _maxSpinSpeed = 450f;
    [SerializeField] private float _waveAmplitude = 1f;
    [SerializeField] private float _waveSpeed = 1f;
    [SerializeField] private float _waveOffset = 0f;

    private int _spinLightsLength = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _spinLightsLength = _spinLights.Length;
        _spinSpeeds = new float[_spinLightsLength];

        // Random Spin Speeds
        for (int i = 0; i < _spinLights.Length; i++)
        {
            _spinSpeeds[i] = Random.Range(_minSpinSpeed, _maxSpinSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Set up for Rotation
        Vector3[] _rotations = new Vector3[_spinLightsLength];

        // The wave for the pulse
        float _wave = _waveAmplitude * Mathf.Sin(Time.time * _waveSpeed) + _waveOffset;
        Vector3 _pulse = new Vector3(_wave, _wave);

        // For the animation
        for (int i = 0; i < _spinLightsLength; i++)
        {
            // Rotation
            _rotations[i].z = _spinSpeeds[i] * Time.deltaTime;
            _spinLights[i].Rotate(_rotations[i]);

            // Pulse
            //_waves[i] = _waveAmplitude * Mathf.Sin(Time.time * _waveSpeed) + _waveOffset;
            //_pulses[i] = new Vector3(_waves[i], _waves[i]);
            _spinLights[i].localScale = _pulse;
        }
    }
}
