using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;

public class FacebookController : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        FB.Init(this.OnInitComplete, this.OnHideUnity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnInitComplete()
    {
       
    }

    private void OnHideUnity(bool isGameShown)
    {

    }  
}
