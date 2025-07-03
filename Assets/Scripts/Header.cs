using TMPro;
using UnityEngine;

/// <summary>
/// Updates the Header children UI elements.
/// </summary>
public class Header : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _totalMuffinsText;

    /// <summary>
    /// Updates the total muffin counter in the header.
    /// </summary>
    /// <param name="counter">Current total muffins</param>
    public void UpdateTotalMuffins(int counter)
    {
        _totalMuffinsText.text = counter == 1 ? "1 Muffin" : $"{counter} Muffins";
    }
}
