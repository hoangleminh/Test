using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacesMoving : MonoBehaviour {
    
    public float speed;
    public float speed2;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        SpaceMoving();
	}

    public void SpaceMoving()
    {
        if (CarController.instance.score < 10)
        {
            Vector3 temp2 = transform.position;
            temp2.y -= speed * Time.deltaTime;
            transform.position = temp2;
        }
        else
        {
            Vector3 temp3 = transform.position;
            temp3.y -= speed2 * Time.deltaTime;
            transform.position = temp3;
        }
        
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
