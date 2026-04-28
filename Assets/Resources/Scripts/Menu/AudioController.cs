using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio; /*Librerias de audio*/

public class AudioController : MonoBehaviour
{
    public bool musicMute; /*Mutear*/
    public bool soundMute;
    public bool masterMute;
    public float previousMusic = 0; /*Valor de volumen inicial*/
    public float previousSound = 0;
    public float previousMaster = 0;
    public AudioMixer audioMixer; /*Llamamos a mixer de audio*/

    void Start()
    {
        
    }

    void Update()
    {
        audioMixer = Resources.Load<AudioMixer>("MainMixer");
    }
    public float GetLevel(string bus)
    {
        float value;
        bool result = audioMixer.GetFloat(bus, out value); /*Devuelve el nivel de volumen del bus*/
        if (result)
        {
            return value;
        }
        else
        {
            return 0f;
        }
    }
    public void MasterVolume(Slider volume)
    {
        audioMixer.SetFloat("Master", volume.value); /*Iguala los volumenes al valor que haya en el slider*/
    }
    public void SoundVolume(Slider volume)
    {
        audioMixer.SetFloat("Sound", volume.value);
    }
    public void MusicVolume(Slider volume)
    {
        audioMixer.SetFloat("Music", volume.value);
    }
    public void MasterMute()
    {
        if (masterMute) /*mutear volumenes*/
        {
            masterMute = false;
            audioMixer.SetFloat("Master", previousMaster); /*Mientras no este muteado sigue oyendose, hasta que se mutee*/
        }
        else
        {
            masterMute = true;
            previousMaster = GetLevel("Master");
            audioMixer.SetFloat("Master", -80);
        }
        if (musicMute)
        {
            musicMute = false;
            audioMixer.SetFloat("Music", previousMusic);
        }
        else
        {
            musicMute = true;
            previousMusic = GetLevel("Music");
            audioMixer.SetFloat("Music", -80);
        }
        if (soundMute)
        {
            soundMute = false;
            audioMixer.SetFloat("Sound", previousSound);
        }
        else
        {
            soundMute = true;
            previousSound = GetLevel("Sound");
            audioMixer.SetFloat("Sound", -80);
        }
    }
}
