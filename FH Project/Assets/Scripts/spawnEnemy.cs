using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    public Transform Spawnpoint;
    public GameObject Enemy;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        Instantiate(Enemy, Spawnpoint.position, Spawnpoint.rotation);

    }

}