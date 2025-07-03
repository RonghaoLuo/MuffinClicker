using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    [SerializeField] private Sprite[] _desserts;
    private int _dessertsCount;

    private void Start()
    {
        _dessertsCount = _desserts.Length;
    }

    public Sprite[] GetDessertSpriteArray()
    {
        return _desserts;
    }

    public int DessertsCount()
    {
        return _dessertsCount;
    }

    public Sprite GetDessertSprite(int index)
    {
        return _desserts[index];
    }
}
