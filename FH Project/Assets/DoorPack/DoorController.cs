using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public bool isOpen = false;
    public AudioSource creak0;
    public AudioSource creak1;
    public AudioSource creak2;
    public AudioSource creak3;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            //var object = Camera.main.ScreenPointToRay(Input.mousePosition);
            var radius = 10;
            var selected = Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,
                    Camera.main.nearClipPlane)), out hit, radius);
            if (selected)
            {
                if (hit.collider.CompareTag("door"))
                {
                    var open = hit.collider.transform.GetComponent<Animator>().GetBool("open");
                    hit.collider.transform.GetComponent<Animator>().SetBool("open", !open);
                    if(isOpen == false)
                    {
                        int creaksound  =Random.Range(0, 4);
                        if(creaksound==0)
                        {
                            creak0.Play();
                        }
                        if (creaksound == 1)
                        {
                            creak1.Play();
                        }
                        if (creaksound == 2)
                        {
                            creak2.Play();
                        }
                        if (creaksound == 3)
                        {
                            creak3.Play();
                        }

                    }
                }

            }
        }
    }
}


