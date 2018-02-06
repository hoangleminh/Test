using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {
    public AudioSource titlemusic;
    public AudioSource gamemusic;
    public AudioSource bossmusic;
    public AudioClip Buttonclicks;

    public static MusicController _instance;
    public static MusicController instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        _instance = this;
    }
    // Use this for initialization
    void Start () {
        PlayTitleMusic();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void PlayTitleMusic()
    {
        gamemusic.Stop();
        bossmusic.Stop();
        titlemusic.Play();
    }

    public void PlayGameMusic()
    {
        if(titlemusic.isPlaying)
        {
            titlemusic.Stop();
        }
        if(!gamemusic.isPlaying)
        {
            gamemusic.Play();
        }
        StartCoroutine(PlayBossMusic());
    }

    IEnumerator PlayBossMusic()
    {
        yield return new WaitForSeconds(10);
        gamemusic.Stop();
        bossmusic.Play();
    }

    public void ButtonClickSound()
    {
        PlayEffect(Buttonclicks);
    }

    public void PlayEffect(AudioClip effectsound)
    {
        GameObject playEffectObj = new GameObject();
        playEffectObj.AddComponent<AudioSource>();
        AudioSource audiosource = playEffectObj.GetComponent<AudioSource>();
        audiosource.PlayOneShot(effectsound);
        Destroy(playEffectObj, effectsound.length);
    }
}
