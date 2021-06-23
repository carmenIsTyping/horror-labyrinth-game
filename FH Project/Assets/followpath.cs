using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class followpath : MonoBehaviour
{
    public Transform[] target;
    public float speed;
    private int current;
    public Transform player;
    public bool isChasing;

    Animator anim;



    private void Awake()
    {
        player = GameObject.Find("First Person Player").transform;
        //agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        anim = GameObject.Find("Mesh").GetComponent<Animator>();
        
    }

    void Update()
    {
        //Check for sight
        Vector3 targetDirection = player.position - transform.position;
        float angle = Vector3.Angle(targetDirection, transform.forward);
        if(angle < 45.0f){
            isChasing = true;
            speed = 8.0f;
            anim.SetBool("isChasing", true);
        }
        else
        {
            isChasing = false;
            speed = 2f;  
            anim.SetBool("isChasing", false); 
        }
        Patrolling();
        

    }



    private void Patrolling()
    {
        if (transform.position != target[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
            transform.LookAt(target[current]);


            //rotate towards next target..
            //Vector3 direction = target[current].position - transform.position;
            //Quaternion rotation = Quaternion.LookRotation(direction);
            //transform.rotation = rotation;
        }
        else
        {
            current = (current + 1) % target.Length;
        }
    }




}