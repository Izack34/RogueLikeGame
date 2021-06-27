using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Enemies;

    public void Spawn(){
        int i = Random.Range(0, Enemies.Length);

        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.SamplePosition(transform.position, out hit, 2.0f, UnityEngine.AI.NavMesh.AllAreas);

        Instantiate(Enemies[i], hit.position, Quaternion.identity);
    }
}
