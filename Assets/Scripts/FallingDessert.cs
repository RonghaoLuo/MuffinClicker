using UnityEngine;
using UnityEngine.UI;

public class FallingDessert : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 200f;

    [SerializeField] private Image _image;
    [SerializeField] private Sprite[] _desserts;

    private void Start()
    {
        int _dessertsLength = _desserts.Length;
        int _randomIndex = Random.Range(0, _dessertsLength);
        Sprite _randomTexture = _desserts[_randomIndex];
        _image.sprite = _randomTexture;
    }

    void Update()
    {
        transform.Translate(0, -_moveSpeed * Time.deltaTime, 0);
        
        if (transform.position.y <= -84) 
            Destroy(gameObject);
    }
}
