using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerController : MonoBehaviour
{
    public AudioManager audioManager;
    public Slider[] sliders;

    private void Start()
    {
        if (audioManager == null)
        {
            Debug.LogError("AudioManager reference is not set.");
            return;
        }

        if (sliders.Length != audioManager.audioMixers.Length)
        {
            Debug.LogError("Number of sliders does not match number of audio mixers.");
            return;
        }

        SetupSliders();
    }

    private void SetupSliders()
    {
        for (int i = 0; i < audioManager.audioMixers.Length; i++)
        {
            var mixer = audioManager.audioMixers[i];
            var parameterName = audioManager.mixerParameters[i].parameterName;
            var slider = sliders[i];

            // Set initial value of slider based on the AudioMixer parameter
            float currentVolume;
            mixer.GetFloat(parameterName, out currentVolume);
            slider.value = Mathf.Pow(10, currentVolume / 20); // Convert dB to linear value

            // Add listener to handle slider changes
            slider.onValueChanged.RemoveAllListeners(); // Remove existing listeners to avoid duplicates
            slider.onValueChanged.AddListener(value =>
            {
                float dbValue = Mathf.Log10(value) * 20; // Convert linear value to dB
                mixer.SetFloat(parameterName, dbValue);
            });
        }
    }

    // Call this method whenever you want to reinitialize or update sliders
    public void UpdateSliders()
    {
        SetupSliders();
    }
}
