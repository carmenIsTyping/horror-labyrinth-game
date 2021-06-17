using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{

    public bool isOpen = false;
    public GameObject quizOverlay;
    private QuestionController questionController;
    public AudioSource creak0;
    public AudioSource creak1;
    public AudioSource creak2;
    public AudioSource creak3;


    void Start()
    {
        questionController = quizOverlay.GetComponent<QuestionController>();
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            //var object = Camera.main.ScreenPointToRay(Input.mousePosition);
            var radius = 10;
            var selected = Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2,
                    Camera.main.nearClipPlane)), out hit, radius);
            if (selected)
            {
                if (hit.collider.CompareTag("door"))
                {
                    //ab hier öffnen der Tür
                    isOpen = hit.collider.transform.GetComponent<Animator>().GetBool("open");

                    if (isOpen == true)
                    {
                        HideDoorQuiz();
                        OpenDoor(hit);
                    }
                    else
                    {
                        isOpen = OpenDoorQuiz(hit);
                    }
                }

            }
        }
    }

    void OpenDoor(RaycastHit hit)
    {
        if (isOpen == false)
        {
            int creaksound = Random.Range(0, 4);
            if (creaksound == 0)
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
        hit.collider.transform.GetComponent<Animator>().SetBool("open", true);
        // "!isOpen" instead of "true" if we want to close doors again
    }


    public bool OpenDoorQuiz(RaycastHit hit)
    {
        questionController.Show(hit);

        return isOpen;
    }

    void HideDoorQuiz()
    {
        questionController.Hide();
    }

}


