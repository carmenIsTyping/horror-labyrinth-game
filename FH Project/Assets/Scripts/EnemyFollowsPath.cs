using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowsPath : MonoBehaviour
{
    public Transform[] target;
    public float speed = 5f;
    private int current;


    public bool activated = false;

    void Update()
    {
        if(activated){
            

            if(transform.position != target[current].position)
            {
                Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
                GetComponent<Rigidbody>().MovePosition(pos);

                //rotate towards next target
                Vector3 direction = target[current].position - transform.position;
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = rotation;
                
            }        
            else
            {
                current = (current + 1) % target.Length;
            }
        }
    }
}
