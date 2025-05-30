using UnityEngine;

/// <summary>
/// 1. Floats the text upwards
/// 2. Fades the text
/// 3. Destrys the text
/// </summary>

public class FloatingText : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, _moveSpeed * Time.deltaTime, 0);
    }
}
