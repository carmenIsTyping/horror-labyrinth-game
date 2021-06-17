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

    public int currentQuestion;
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
        currentQuestion = Random.Range(0, QnA.Count);
        questionTxt.text = QnA[currentQuestion].Question;
        Debug.Log("Generated Question: " + currentQuestion);
    }

    public void Show(RaycastHit hit)
    {
        Debug.Log("Showing QuestionController Window");
        Time.timeScale = 0f;
        gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        door = hit;
        //generateQuestion();
    }

    public void Hide()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    public bool getAnswer()
    { 
        if (string.Compare(userInput, currentAnswer) == 0);
        {
            door.collider.transform.GetComponent<Animator>().SetBool("open", true);
            Hide();
            return true;
        }
        WrongAnswer();
        return false;
    }

    public void WrongAnswer()
    {
        Debug.Log("Wrong Answer stuff here");
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
