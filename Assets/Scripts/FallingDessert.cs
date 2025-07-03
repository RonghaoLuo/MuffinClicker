using UnityEngine;
using UnityEngine.UI;

public class FallingDessert : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 200f;

    [SerializeField] private Image _image;
    [SerializeField] private SpriteManager _spriteManager;

    private void Start()
    {
        _spriteManager = FindAnyObjectByType<SpriteManager>();

        int randomIndex = Random.Range(0, _spriteManager.DessertsCount());
        _image.sprite = _spriteManager.GetDessertSprite(randomIndex);
    }

    void Update()
    {
        transform.Translate(0, -_moveSpeed * Time.deltaTime, 0);
        
        if (transform.position.y <= -84) 
            Destroy(gameObject);
    }
}
