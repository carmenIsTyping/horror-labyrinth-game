using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{
    public string answer;
    public GameObject questionDisplay;
    public GameObject inputField;

    public void StoreAnswer()
    {
        answer = inputField.GetComponent<Text>().text;
        questionDisplay.GetComponent<Text>().text = "Answer: " + answer;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
