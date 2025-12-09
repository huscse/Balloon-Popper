using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        if (volumeSlider != null)
        {
            // Set slider to current global volume
            volumeSlider.value = AudioListener.volume;
            // When slider changes, call SetVolume
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value;
    }
}
