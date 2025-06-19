using UnityEngine;

public class SpinPulseTransforms : MonoBehaviour
{
    [SerializeField] private Transform[] _spinLightArray;
    [SerializeField] private float[] _spinSpeedArray; // degrees per second
    [SerializeField] private float _minSpinSpeed = 180f, _maxSpinSpeed = 360f;
    [SerializeField] private float[] _waveAmplitudeArray;
    [SerializeField] private float _minAmp = 0.1f, _maxAmp = 0.2f; // 0.2
    [SerializeField] private float[] _waveSpeedArray;
    [SerializeField] private float _minWaveSpeed = 2f, _maxWaveSpeed = 4f; // 3.5
    [SerializeField] private float _waveOffset = 0.84f;

    private int _numOfSpinLights = 0;
    private Vector3[] _rotations;
    private float[] _waves;
    private Vector3[] _pulses;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _numOfSpinLights = _spinLightArray.Length;

        _spinSpeedArray = new float[_numOfSpinLights];
        _waveAmplitudeArray = new float[_numOfSpinLights];
        _waveSpeedArray = new float[_numOfSpinLights];

        // Generate Random Spin Speeds, Pulse Amplitudes, and pulse wave speeds
        for (int i = 0; i < _spinLightArray.Length; i++)
        {
            _spinSpeedArray[i] = Random.Range(_minSpinSpeed, _maxSpinSpeed);
            _waveAmplitudeArray[i] = Random.Range(_minAmp, _maxAmp);
            _waveSpeedArray[i] = Random.Range(_minWaveSpeed, _maxWaveSpeed);
        }

        // Set up for Rotation
        _rotations = new Vector3[_numOfSpinLights];
        _waves = new float[_numOfSpinLights];
        _pulses = new Vector3 [_numOfSpinLights];
    }

    // Update is called once per frame
    void Update()
    {
        // The wave for the pulse
        //_wave = _waveAmplitude * Mathf.Sin(Time.time * _waveSpeed) + _waveOffset;
        //_pulse = new Vector3(_wave, _wave);

        // For the animation
        for (int i = 0; i < _numOfSpinLights; i++)
        {
            // Rotation
            _rotations[i].z = _spinSpeedArray[i] * Time.deltaTime;
            _spinLightArray[i].Rotate(_rotations[i]);

            // Pulse
            _waves[i] = _waveAmplitudeArray[i] * Mathf.Sin(Time.time * _waveSpeedArray[i]) + _waveOffset;
            _pulses[i] = new Vector3(_waves[i], _waves[i]);

            _spinLightArray[i].localScale = _pulses[i];
        }
    }
}
