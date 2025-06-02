using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MyFirstScript : MonoBehaviour
{
    [SerializeField] private int _muffinsPerClick = 1;
    [SerializeField] private TextMeshProUGUI _totalMuffinsText;
    [Range(0f, 1f)] [SerializeField] private float _critChance = 0.01f;
    [SerializeField] private Transform[] _spinLights;
    [SerializeField] private float[] _spinSpeeds; // degrees per second
    [SerializeField] private float _minSpinSpeed = 270f, _maxSpinSpeed = 450f;
    [SerializeField] private float _waveAmplitude = 1f;
    [SerializeField] private float _waveSpeed = 1f;
    [SerializeField] private float _waveOffset = 0f;
    [SerializeField] private Texture2D[] _desserts;
    [SerializeField] private RawImage _image;

    // For pop-up numbers after clicking muffin
    [SerializeField] private float _textMinXPos, _textMaxXPos, _textMinYPos, _textMaxYPos;

    private int _counter = 0;
    private int _spinLightsLength = 0;

    // Prefabs
    [SerializeField] private TextMeshProUGUI _textRewardPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello, World!");
        UpdateTotalMuffins();
        _spinLightsLength = _spinLights.Length;
            
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

    public void OnMuffinClicked()
    {
        int addedMuffins = 0;
        float _random = Random.value;               // between 0.0 and 1.0
        if (_random <= _critChance)                 // slightly over 1%, like 1.00001%
        {
            //_counter += _muffinsPerClick * 10;
            addedMuffins = _muffinsPerClick * 10;
            Debug.Log("Critical Hit!");
        }
        else
        {
            //_counter += _muffinsPerClick;
            addedMuffins = _muffinsPerClick;
        }
        _counter += addedMuffins;
            
        UpdateTotalMuffins();
        //Debug.Log("Muffin = " + _counter + ", Random # = " + _random);

        // Random Dessert
        int _dessertsLength = _desserts.Length;
        int _randomIndex = Random.Range(0, _dessertsLength);
        Texture2D _randomTexture = _desserts[_randomIndex];
        _image.texture = _randomTexture;

        // Reward pop-up text
            // Clone
        TextMeshProUGUI textRewardClone = Instantiate(_textRewardPrefab, transform);
            // Random Position
        textRewardClone.transform.localPosition = MyToolbox.GetRandomVector2(_textMinXPos, _textMaxXPos, _textMinYPos, _textMaxYPos);
            // Get the TMP Component
        //TextMeshProUGUI textRewardText = textRewardClone.GetComponent<TextMeshProUGUI>();
            // Set the text
        textRewardClone.text = "+" + addedMuffins;

        // Testing Color.Lerp
        //Debug.Log(Color.Lerp(Color.white, Color.clear, 2.5f));
    }

    private void UpdateTotalMuffins()
    {
        if (_counter == 1)
        {
            _totalMuffinsText.text = "1 Muffin";

        }
        else
        {
            _totalMuffinsText.text = _counter.ToString() + " Muffins";

        }
    }
}
