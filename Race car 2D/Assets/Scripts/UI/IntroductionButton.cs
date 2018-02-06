using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionButton : MonoBehaviour {
    public ParticleSystem explosions;
	// Use this for initialization
	void Start () {
        StartCoroutine(ShowIntroductionPanel());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator ShowIntroductionPanel()
    {
        SpawnMods.instance.StopAllCoroutines();
        explosions.Play();
        yield return new WaitForSeconds(1);
        explosions.Stop();
        UIController.instance.ShowStartPanel();
    }
}
