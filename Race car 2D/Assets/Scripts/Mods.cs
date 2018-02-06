using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mods : MonoBehaviour {
    public float speed;
    public float speed2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ModMovenment();
	}

    public void ModMovenment()
    {
        if(CarController.instance.score<10)
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;
            transform.position = temp;
        }
        else
        {
            Vector3 temp2 = transform.position;
            temp2.y -= speed2 * Time.deltaTime;
            transform.position = temp2;
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
