using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombies : MonoBehaviour
{
    public GameObject Zombie;
    private float spawntime = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ZombieWave());
    }

    private void SpawnZombie()
    {
        GameObject zombie1 = Instantiate(Zombie) as GameObject;
    }

    IEnumerator ZombieWave()
    {
        Debug.Log(GameCtrl.instance.timeLeft);
        if (GameCtrl.instance.timeLeft <= 0)
        {
            yield return new WaitForSeconds(spawntime);
            SpawnZombie();
        }
        
    }
}
