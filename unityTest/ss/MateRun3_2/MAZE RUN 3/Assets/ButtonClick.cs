using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonClick : MonoBehaviour
{
    private string currentButtonName = "";
    private string[] AnswersPlayer = new string[8];
    private string[] RightAnswers = new string[] { "ButtonA", "ButtonB", "ButtonC", "ButtonD", "ButtonA", "ButtonB", "ButtonC", "ButtonD" };
    private int RightAnswersPlayer;
    private int FalseAnswersPlayer;
    private bool Answercheck = false;

    public Transform dialogueBoxGUIQuestionButtons;

    public int CurrentButtonClick3;
    public int currentButtonClick;

    private DialogueSystem dialogueSystem;
    ColorBlock cb2;
    Button ButtonA1;
    Text txt2;


    //public void SetText(string txt)
    //{
    //    Text txt2 = transform.Find("TextA").GetComponent<Text>();
    //    txt2.text = "hello";

    //}
    void Start()
    {
        currentButtonClick = 0;
        dialogueSystem = DialogueSystem.FindObjectOfType<DialogueSystem>();
    }

    public bool Answercheck_()
    {
        return Answercheck;
    }

    public void setButtonName(string txt)
    {
        Answercheck = false;
        currentButtonName = txt;
        AnswersPlayer[currentButtonClick] = currentButtonName;

        txt2 = GameObject.Find("CheckAns").GetComponent<Text>();
        Answercheck = false;
        if (AnswersPlayer[dialogueSystem.currentQuestionIndex-1] == RightAnswers[dialogueSystem.currentQuestionIndex-1])
        {
            ButtonA1 = GameObject.Find(currentButtonName).GetComponent<Button>();
            ColorBlock cb = ButtonA1.colors;
            cb.selectedColor = Color.green;
            ButtonA1.colors = cb;
            RightAnswersPlayer++;
            txt2.text = "Correct";
            currentButtonClick = 1;
            StartCoroutine(ExampleCoroutine());

            dialogueSystem.DialogueBoxButtonSetActiveFalse();
            Answercheck = true;
        }
        else
        {
            ButtonA1 = GameObject.Find(currentButtonName).GetComponent<Button>();
            cb2 = ButtonA1.colors;
            cb2.selectedColor = Color.red;
            ButtonA1.colors = cb2;
            FalseAnswersPlayer++;
            txt2.text = "False";

            StartCoroutine(ExampleCoroutine());

            dialogueSystem.DialogueBoxButtonSetActiveFalse();
            Answercheck = true;
        }
        currentButtonClick++;
        CurrentButtonClick3 += 1;
        
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1f);
        cb2.selectedColor = Color.grey;
        ButtonA1.colors = cb2;
        yield return new WaitForSeconds(5f);
    }



    //public string CurrentButtonName { get => currentButtonName; set => currentButtonName = value; }
    //public int CurrentButtonClick { get => currentButtonClick; set => currentButtonClick = value; }
    //public bool Answercheck1 { get => Answercheck; set => Answercheck = value; }

}
