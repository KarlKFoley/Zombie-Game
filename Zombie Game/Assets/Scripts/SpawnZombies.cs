using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This code is used to trigger zombies spawning of zombies either when game ends or when 
/// understanding of basic startCorotine and IEnumberator from https://www.youtube.com/watch?v=E7gmylDS1C4
/// </summary>
public class SpawnZombies : MonoBehaviour
{
    public GameObject Zombie;
    public float spawntime = 1.0f;
    public GameObject[] spawnTriggers;
    public GameObject[] spawnPoints;
    public bool[] pointTriggered;
    public bool[] triggeredOnce;
    public static SpawnZombies instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (GameCtrl.instance.zombiesTriggered)
        {
            int location = 0;
            foreach (GameObject point in spawnTriggers)
            {
                if (pointTriggered[location] && !triggeredOnce[location] || GameCtrl.instance.timeLeft<=-10 && !triggeredOnce[location])
                {
                    
                    StartCoroutine(ZombieWave(new Vector3(spawnPoints[location].transform.position.x, spawnPoints[location].transform.position.y, 0)));
                    triggeredOnce[location] = true;
                }
                location++;

            }
        }

    }
    public  IEnumerator ZombieWave(Vector3 location)
    {
        while (true)
        {
            if (GameCtrl.instance.timeLeft <= 0 || GameCtrl.instance.zombiesTriggered)
            {
                yield return new WaitForSeconds(spawntime);
                SpawnZombie(location);
            }
        }

    }

    private void SpawnZombie(Vector3 location)
    {
        GameObject zombie1 = Instantiate(Zombie) as GameObject;
        zombie1.transform.position = location;
    }

    public IEnumerator ZombieWave()
    {
        
        while (true)
        {
            if (GameCtrl.instance.timeLeft <= 0 || GameCtrl.instance.zombiesTriggered)
            {
                yield return new WaitForSeconds(spawntime);
                SpawnZombie(new Vector3(this.transform.position.x + 5f, this.transform.position.y, 0));
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                GameCtrl.instance.zombiesTriggered = true;
                StartCoroutine(ZombieWave());
                break;
        }
    }
}
