using UnityEngine;

public class DessertRain : MonoBehaviour
{
    private float _timer = 0f;

    [SerializeField] private float _generateInterval = 1f;

    // Prefabs
    [SerializeField] private GameObject _fallingDessertPrefab;

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        while (_timer >= _generateInterval)
        {
            GenerateFallingDessert();
            _timer -= _generateInterval;
        }
    }

    private void GenerateFallingDessert()
    {
        Vector2 startPosition = new Vector2(Random.Range(27, 980), 600);

        GameObject newDessert = Instantiate(_fallingDessertPrefab, transform);
        newDessert.transform.position = startPosition;
    }
}
