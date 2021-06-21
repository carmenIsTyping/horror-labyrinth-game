using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{

    public List<QuestionsAndAnswers> QnA;

    public string userInput;
    public Text inputField;
    public Text questionTxt;
    private RaycastHit door;

    public static int randIndex;
    public string currentAnswer = "Hallo";

    private void Awake()
    {
        Hide();
    }

    public void StoreAnswer()
    {
        userInput = inputField.GetComponent<Text>().text;
        getAnswer();
    }

    void generateQuestion()
    {
        randIndex = Random.Range(0, QnA.Count);
        questionTxt.text = QnA[randIndex].Question;
    }

    public void Show(RaycastHit hit)
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        door = hit;
        if (gameObject.activeSelf == false)
        {
            generateQuestion();
        }
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    public void getAnswer()
    {
        if (string.Compare(userInput, QnA[randIndex].Answer) == 0)
        {
            door.collider.transform.GetComponent<Animator>().SetBool("open", true);
            Hide();
        }else
        {
            WrongAnswer();
        }
    }

    public void WrongAnswer()
    {
        //inputField.color = Color.red;
    }

    /**
    for mulitple Choice Quizzes:
    GameObject[4] options; <-- UI Buttons initialized in Unity on top of the File

    public void SetAnswers()
    {
    for(int i = 0; i < options.Lenght; i++){
        options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
    }
    }**/
}
