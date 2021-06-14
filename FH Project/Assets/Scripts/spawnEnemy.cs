using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
       public GameObject Enemy;

       void OnTriggerEnter(Collider other)
       {
           Enemy.GetComponent<EnemyFollowsPath>().activated = true;
       }

    

}