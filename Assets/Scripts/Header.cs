using TMPro;
using UnityEngine;

public class Header : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _totalMuffinsText;

    public void UpdateTotalMuffins(int counter)
    {
        if (counter == 1)
        {
            _totalMuffinsText.text = "1 Muffin";

        }
        else
        {
            _totalMuffinsText.text = counter.ToString() + " Muffins";

        }
    }
}
