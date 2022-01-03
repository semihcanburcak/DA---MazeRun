using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonClick : MonoBehaviour
{
    private string currentButtonName = "";
    private int currentButtonClick = 0;
    private string[] AnswersPlayer = new string[5];
    private string[] RightAnswers = new string[] { "ButtonA", "ButtonB" };
    private int RightAnswersPlayer;
    private int FalseAnswersPlayer;
    private bool Answercheck;
    Text txt2;


    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
    }



    public void SetText(string txt)
    {
        Text txt2 = transform.Find("TextA").GetComponent<Text>();
        txt2.text = "hello";

    }


    public void setButtonName(string txt)
    {
        currentButtonName = txt;
        AnswersPlayer[currentButtonClick] = currentButtonName;
        checkAnswer();

    }
    public bool checkAnswer()
    {
        txt2 = GameObject.Find("CheckAns").GetComponent<Text>();
        Answercheck = false;
        if (AnswersPlayer[currentButtonClick] == RightAnswers[currentButtonClick])
        {
            Button ButtonA1 = GameObject.Find("ButtonA").GetComponent<Button>();
            ColorBlock cb = ButtonA1.colors;
            cb.selectedColor = Color.green;
            ButtonA1.colors = cb;
            RightAnswersPlayer++;
            Answercheck = true;
            txt2.text = "Correct";
        }
        else
        {
            FalseAnswersPlayer++;
            Answercheck = false;
            txt2.text = "False";

        }
        currentButtonClick++;
        return Answercheck;
    }

    public string CurrentButtonName { get => currentButtonName; set => currentButtonName = value; }
    public int CurrentButtonClick { get => currentButtonClick; set => currentButtonClick = value; }
}
