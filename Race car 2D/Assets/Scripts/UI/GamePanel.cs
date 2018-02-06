using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
        AdsController.instance.ShowAdmodBanner();
        AdsController.instance.RequestTrunggian();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPauseButtonClick()
    {
        Time.timeScale = 0;
        UIController.instance.ShowGamePanel();
    }

    public void OnReplayButtonClick()
    {
        Time.timeScale = 1;
        UIController.instance.ShowGameplay();
    }
}
