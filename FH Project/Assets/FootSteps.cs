using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioSource footsteps;
    public float delay = 0.5f;

    public float nextStep = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
        {
            nextStep -= Time.deltaTime;
            if (nextStep <= 0)
            {
                footsteps.Play(0);
                nextStep += delay;
            }
        }
    }
}
