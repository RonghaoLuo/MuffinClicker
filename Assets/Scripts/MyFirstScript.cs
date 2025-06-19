using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MyFirstScript : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Texture2D[] _desserts;
    [SerializeField] private RawImage _image;

    // For pop-up numbers after clicking muffin
    [SerializeField] private float _textMinXPos, _textMaxXPos, _textMinYPos, _textMaxYPos;
    
    // Prefabs
    [SerializeField] private TextMeshProUGUI _textRewardPrefab;

    public void OnMuffinClicked()
    {
        int addedMuffins = _gameManager.AddMuffins();

        // Random Dessert on every click
        int _dessertsLength = _desserts.Length;
        int _randomIndex = Random.Range(0, _dessertsLength);
        Texture2D _randomTexture = _desserts[_randomIndex];
        _image.texture = _randomTexture;

        // Reward pop-up text
            // Clone
        TextMeshProUGUI textRewardClone = Instantiate(_textRewardPrefab, transform);
            // Random Position
        textRewardClone.transform.localPosition = MyToolbox.GetRandomVector2(_textMinXPos, _textMaxXPos, _textMinYPos, _textMaxYPos);
            // Set the text
        textRewardClone.text = "+" + addedMuffins;
    }
}
