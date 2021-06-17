using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{

    public List<QuestionsAndAnswers> QnA;

    public string answer;
    public Text questionTxt;
    public GameObject inputField;
    public int currentQuestion;
    public string currentAnswer;

    public void Start()
    {
        Show();
    }
    private void Awake()
    {
        Hide();
    }

    public void StoreAnswer()
    {
        answer = inputField.GetComponent<Text>().text;
    }

    void generateQuestion()
    {
        currentQuestion = Random.Range(0, QnA.Count);
        questionTxt.text = QnA[currentQuestion].Question;
    }

    public void Show()
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
        generateQuestion();
    }

    public void Hide()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    public bool getAnswer()
    {
        StoreAnswer();

        if(answer == currentAnswer)
        {
            Hide();
            return true;
        }
        return false;
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
