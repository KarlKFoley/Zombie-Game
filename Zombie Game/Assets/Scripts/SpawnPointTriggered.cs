using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointTriggered : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            
            case "Enemy":
                int foundTrigger = 0;
                bool found = false;
                foreach(GameObject point in SpawnZombies.instance.spawnTriggers)
                {
                    if(SpawnZombies.instance.spawnTriggers[foundTrigger] == point)
                    {
                        found = true;
                    }
                    else if(!found)
                    {
                        foundTrigger++;
                    }
                }
                SpawnZombies.instance.pointTriggered[foundTrigger] = true;
                break;
        }
    }
}
