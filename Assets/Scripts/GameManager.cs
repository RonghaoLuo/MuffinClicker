using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _counter = 0;

    [SerializeField][Range(0f, 1f)] private float _critChance = 0.01f;
    [SerializeField] private int _muffinsPerClick = 1;
    [SerializeField] private TextMeshProUGUI _totalMuffinsText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello, World!");
        UpdateTotalMuffins();
        
    }

    public int AddMuffins()
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

        return addedMuffins;
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