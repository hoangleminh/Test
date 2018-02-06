using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : MonoBehaviour {

	void OnEnable () {
        AdsController.instance.ShowAdmodBanner();
        AdsController.instance.DestroyAdmodBanner();
	}

    void OnDisable()
    {
        
    }

    void Update () {
		
	}

    public void OnStartButtonClick()
    {
        UIController.instance.ShowGameplay();
        Time.timeScale = 1;
        MusicController.instance.ButtonClickSound();
    }
}
