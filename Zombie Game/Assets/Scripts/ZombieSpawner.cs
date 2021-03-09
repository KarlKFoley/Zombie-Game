using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject Zombie;
    public float spawntime = 1.0f;


    private void Awake()
    {
            StartCoroutine(ZombieWave());
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
                yield return new WaitForSeconds(spawntime);
                SpawnZombie(new Vector3(this.transform.position.x, this.transform.position.y, 0));
        }

    }
}
