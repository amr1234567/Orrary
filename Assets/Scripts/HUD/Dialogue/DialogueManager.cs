using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public Button start;
    public Button hide;
    public Button nextButton;
    public TextMeshProUGUI question;
    public TextMeshProUGUI answer;


    //private int counter = 0;

    public static int questionNum = -1;

    private Queue<string> questions;
    private Queue<string> answers;


    private string sentence2;

    //Delay time between typing letter by letter
    const float delay = 0.05f;
    private bool once = true;

    private void Start()
    {
        questions = new Queue<string>();
        answers = new Queue<string>();


        answer.text = "";

        nextButton.enabled = false;
        nextButton.GetComponentInChildren<TextMeshProUGUI>().text ="";

        hide.enabled = false;
        hide.GetComponentInChildren<TextMeshProUGUI>().text = "";
    }


    public void StartQuestions(Dialogue dialogue)
    {
        start.interactable = false;
        start.GetComponentInChildren<TextMeshProUGUI>().text = "";

        if(!question.enabled)
            question.enabled = true;


        questions.Clear();
        answers.Clear();

        nextButton.enabled = false;
        hide.enabled = false;

        for(int i = 0; i < dialogue.questions.Length; i++)
        {
            questions.Enqueue(dialogue.questions[i]);
            answers.Enqueue(dialogue.answers[i]);
        }

        DisplayNextScentence();
    }

    public void DisplayNextScentence()
    {
        if(questions.Count == 0 || answers.Count == 0)
        {
            return;
        }

        string sentence1 = questions.Dequeue();
        sentence2 = answers.Dequeue();

        //question.text = sentence1;


        if(nextButton.enabled && hide.enabled)
        {
            nextButton.enabled = false;
            nextButton.GetComponentInChildren<TextMeshProUGUI>().text = "";

            hide.enabled = false;
            hide.GetComponentInChildren<TextMeshProUGUI>().text = "";
        }

        StartQuestion(sentence1);
    }


    void StartQuestion(string x)
    {
        StopAllCoroutines();
        StartCoroutine(TypeSentence(x));
    }

    void StartAnswer(string x)
    {
        StopAllCoroutines();
        StartCoroutine(TypeSentence2(x));
    }

    IEnumerator TypeSentence(string sentence)
    {
        question.text = "";

        if(answer.text != "" && once)
        {
            answer.text = "";
            once = false;
        }


        foreach (char letter in sentence.ToCharArray())
        {
            question.text += letter;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(0f);

        StartAnswer(sentence2);
    }

    IEnumerator TypeSentence2(string sentence)
    {
        answer.text = "";

        foreach( char letter in sentence.ToCharArray() )
        {
            answer.text += letter;
            yield return new WaitForSeconds(0.001f);
        }

        yield return new WaitForSeconds(0f);

        nextButton.enabled = true;
        nextButton.GetComponentInChildren<TextMeshProUGUI>().text ="Next";

        hide.enabled = true;
        hide.GetComponentInChildren<TextMeshProUGUI>().text = "Hide";

        once = true;

        questionNum++;
    }


    public void HideText()
    {
        if(question.enabled && answer.enabled)
        {
            question.enabled= false;
            answer.enabled= false;
            hide.GetComponentInChildren<TextMeshProUGUI>().text = "Show";
        }
        else
        {
            question.enabled = true;
            answer.enabled = true;
            hide.GetComponentInChildren<TextMeshProUGUI>().text = "Hide";
        }
    }
}
