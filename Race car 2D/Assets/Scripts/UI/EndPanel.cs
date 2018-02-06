using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPanel : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
        AdsController.instance.ShowAdmodBanner();

        int randomValue = Random.RandomRange(1, 3);
        if(randomValue==2)
        {
            AdsController.instance.ShowTrunggian();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnReplayButtonClick()
    {
        UIController.instance.ShowGameplay();
        MusicController.instance.PlayGameMusic();
        MusicController.instance.ButtonClickSound();
    }

    public void OnQuitButtonClick()
    {
        UIController.instance.ShowIntructionPanel();
        MusicController.instance.PlayTitleMusic();
        MusicController.instance.ButtonClickSound();
    }
}
