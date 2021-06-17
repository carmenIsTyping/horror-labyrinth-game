using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fFlashlightScript : MonoBehaviour
{
    public Light Light;
    public AudioClip LightsOn;
    public AudioClip LightsOff;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Light.enabled == true)
            {
                Light.enabled = false;
                GetComponent<AudioSource>().PlayOneShot(LightsOn);
            }
            else
            {
                Light.enabled = true;

                GetComponent<AudioSource>().PlayOneShot(LightsOff);


            }
        }
    }
}
