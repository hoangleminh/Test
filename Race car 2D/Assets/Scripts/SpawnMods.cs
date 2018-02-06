using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMods : MonoBehaviour {
    [SerializeField]
    private GameObject Spaces;
    [SerializeField]
    private GameObject Police;
    [SerializeField]
    private GameObject Ambulance;
    [SerializeField]
    private GameObject Minitruck;

    public static SpawnMods _instance;
    public static SpawnMods instance
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

    public float SpawnRate = 2f;
    int WhatToSpawn;
    float nextSpawn = 0f;

    void Start () {
        
	}

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            WhatToSpawn = Random.RandomRange(1, 7);
            Debug.Log(WhatToSpawn);
            switch (WhatToSpawn)
            {
                case 1:
                    StartCoroutine(SpawnerPolice());
                    StartCoroutine(SpawnSpace());
                    break;
                case 2:
                    StartCoroutine(SpawnerAmbulance());
                    StartCoroutine(SpawnSpace());
                    break;
                case 3:
                    StartCoroutine(SpawnerMinitruck());
                    StartCoroutine(SpawnSpace());
                    break;
                case 4:
                    StartCoroutine(SpawnerPolice());
                    StartCoroutine(SpawnerAmbulance());
                    StartCoroutine(SpawnSpace());
                    break;
                case 5:
                    StartCoroutine(SpawnerAmbulance());
                    StartCoroutine(SpawnerMinitruck());
                    StartCoroutine(SpawnSpace());
                    break;
                case 6:
                    StartCoroutine(SpawnerPolice());
                    StartCoroutine(SpawnerMinitruck());
                    StartCoroutine(SpawnSpace());
                    break;
            }
            nextSpawn = Time.time + SpawnRate;
        }
    }

    IEnumerator SpawnerPolice()
    {
        yield return new WaitForSeconds(1);
        Vector3 temp1 = new Vector3(-2, 7, 0);
        Instantiate(Police, temp1, Quaternion.identity);
    }

    IEnumerator SpawnerAmbulance()
    {
        yield return new WaitForSeconds(1);
        Vector3 temp2 = new Vector3(0, 7, 0);
        Instantiate(Ambulance, temp2, Quaternion.identity);
    }
	
    IEnumerator SpawnerMinitruck()
    {
        yield return new WaitForSeconds(1);
        Vector3 temp3 = new Vector3(2, 7, 0);
        Instantiate(Minitruck, temp3, Quaternion.identity);
    }

    IEnumerator SpawnSpace()
    {
        yield return new WaitForSeconds(1);
        Vector3 temp = new Vector3(0, 7, 0);
        Instantiate(Spaces, temp, Quaternion.identity);
    }
}
