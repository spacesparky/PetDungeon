using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsScript : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void VolumeScript(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
