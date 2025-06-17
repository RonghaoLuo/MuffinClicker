using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _counter = 0;

    [SerializeField] private Header _header;
    [SerializeField][Range(0f, 1f)] private float _critChance = 0.01f;
    [SerializeField] private int _muffinsPerClick = 1;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello, World!");
        _header.UpdateTotalMuffins(_counter);
        
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
        _header.UpdateTotalMuffins(_counter);

        return addedMuffins;
    }
}