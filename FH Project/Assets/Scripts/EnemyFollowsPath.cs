using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowsPath : MonoBehaviour
{     
    public Transform[] target;
    public float speed = 2.0f;
    public int current=0;


    public bool activated = false;

    void Update()
    {

            if(transform.position != target[current].position)
            {
                Vector3 toDirection = Vector3.MoveTowards(transform.position, target[current].position, speed*Time.deltaTime);
                GetComponent<Rigidbody>().MovePosition(toDirection);
            }
            else
            {
                current = (current + 1) % target.Length;
            }  
    }
}
