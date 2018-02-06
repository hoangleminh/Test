using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    private Rigidbody2D carBody;
    private Animator anim;

    private bool isAlive;

    public GameObject spawner;
    public float flag = 0;
    public int score = 0;

    public AudioClip explosions;
    //public ParticleSystem explosion;
    //public ParticleSystem smoke;

    public static CarController _instance;
    public static CarController instance
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
        carBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spawner = GameObject.Find("SpawnMods");
        //explosion.Stop();
        //smoke.Stop();
        isAlive = true;
    }

    public void OnButtonRightClick()
    {
        if(isAlive)
        {
            if (transform.position.x < 2)
            {
                transform.position += Vector3.right * 2;
            }
            MusicController.instance.ButtonClickSound();
        }
    }

    public void OnButtonLeftClick()
    {
        if(isAlive)
        {
            if (transform.position.x > -2)
            {
                transform.position += Vector3.left * 2;
            }
        }
        MusicController.instance.ButtonClickSound();
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Spaces")
        {
            score++;
            if(UIController.instance!=null)
            {
                UIController.instance.SetScore(score);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Mods")
        {
            if(isAlive)
            {
                isAlive = false;
                flag = 1;
                Time.timeScale = 0;
                Destroy(spawner);
                MusicController.instance.PlayEffect(explosions);
            }
            if (UIController.instance != null)
            {
                UIController.instance.ShowEndPanel(score);
            }
        }
    }

    //IEnumerator ShowParticle()
    //{
    //    explosion.Play();
    //    yield return new WaitForSeconds(2);
    //    smoke.Play();
    //    yield return new WaitForSeconds(5);
        
    //}
}
