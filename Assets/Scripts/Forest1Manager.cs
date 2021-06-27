using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest1Manager : MonoBehaviour
{
    public Transform PlaceToSpawnhero;
    public GameObject Hero;

    public GameObject[] Spawns;

    void Awake()
    {
        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.SamplePosition(PlaceToSpawnhero.position, out hit, 2.0f, UnityEngine.AI.NavMesh.AllAreas);
        Instantiate(Hero, hit.position, Quaternion.identity);

        Spawns = GameObject.FindGameObjectsWithTag("MobSpawner");
        Debug.Log(Spawns.Length);
        StartEnemies();
    }

    private void StartEnemies(){
        foreach (GameObject spawn in Spawns)
        {
            spawn.GetComponent<EnemySpawn>().Spawn();
        }
    }
    //monster buff
}
