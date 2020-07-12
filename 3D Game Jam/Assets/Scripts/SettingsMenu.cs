using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public string exposedParameterName;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat(exposedParameterName, volume);
    }
}
