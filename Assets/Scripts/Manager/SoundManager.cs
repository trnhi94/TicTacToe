using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource _buttonClick;
    [SerializeField] private AudioSource _slotClick;
    [SerializeField] private AudioSource _win;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    public void PlayMusic()
    {

    }

    public void PlayButtonClickSound()
    {
        _buttonClick.Play();
    }

    public void PlaySlotClick()
    {
        _slotClick.Play();
    }

    public void PlayWinSound()
    {
        _win.Play();
    }

    public void StopMusic(bool value)
    {
        _music.mute = value;
        if(value == true)
        {
            _music.Stop();
        }
        else
        {
            _music.Play();
        }
    }

    public void StopSound(bool value)
    {
        _buttonClick.mute = value;
        _slotClick.mute = value;
        _win.mute = value;
    }
}
