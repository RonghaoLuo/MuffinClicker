using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _totalMuffins = 0;
    [SerializeField][Range(0f, 1f)] private float _critChance = 0.01f;
    [SerializeField] private int _muffinsPerClick = 1;

    [SerializeField] private Header _header;

    void Start()
    {
        _header.UpdateTotalMuffins(0);
    }

    /// <summary>
    /// Adds muffins according to game stats and updates the header
    /// </summary>
    /// <returns>number of muffins added</returns>
    public int AddMuffins()
    {
        int addedMuffins = 0;
        float _random = Random.value;               // between 0.0 and 1.0
        if (_random <= _critChance)                 // slightly over 1%, like 1.00001%
        {
            addedMuffins = _muffinsPerClick * 10;
            Debug.Log("Critical Hit!");
        }
        else
        {
            addedMuffins = _muffinsPerClick;
        }
        _totalMuffins += addedMuffins;
        _header.UpdateTotalMuffins(_totalMuffins);

        return addedMuffins;
    }
}