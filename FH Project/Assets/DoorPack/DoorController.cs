using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
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
                }

            }
        }
    }
}

