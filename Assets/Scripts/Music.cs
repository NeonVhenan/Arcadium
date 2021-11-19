using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource _background;
    public AudioSource _search;
    public AudioSource _victory;

    bool background_music = true;
    bool search_music = false;
    bool victory_music = false;

    public void BackgroundMusic()
    {

        background_music = true;
        search_music = false;
        victory_music = false;

        _background.Play();
    }

     public void SearchMusic()
    {

        if (_background.isPlaying)
        {
            background_music = false;
        }

        {
            _background.Stop();
        }

        if (_victory.isPlaying)
        {
            victory_music = false;
        }

        {
            _victory.Stop();
        }

        if (!_search.isPlaying && search_music == false)
        {

            _search.Play();
            search_music = true;
        }
    }

    public void VictoryMusic()
    {

        if (_background.isPlaying)
        {
            background_music = false;
        }

        {
            _background.Stop();
        }

        if (_search.isPlaying)
        {
            search_music = false;
        }

        {
            _search.Stop();
        }

        if (!_victory.isPlaying && victory_music == false)
        {

            _victory.Play();
            victory_music = true;
        }
    }
}