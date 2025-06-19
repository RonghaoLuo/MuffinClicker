using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] Slider _volumeSlider;

    void Start()
    {
        AudioListener.volume = _volumeSlider.value; // to apply the volume at the start of game
    }

    public void OnVolumeChanged()
    {
        AudioListener.volume = _volumeSlider.value;
    }
}
