using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueSystem: MonoBehaviour {

    public Text nameText;
    public Text dialogueText;

    public GameObject dialogueGUI;
    public Transform dialogueBoxGUI;
    public Transform dialogueBoxGUIQuestion;
    public Transform dialogueBoxGUIQuestionButtons;

    public float letterDelay = 0.1f;
    public float letterMultiplier = 0.5f;

    public KeyCode DialogueInput = KeyCode.F;

    public string Names;

    public string[] dialogueLines;
    public bool[] dialogueQuestions;
    public int currentDialogueIndex;
    public int currentQuestionIndex;


    public bool letterIsMultiplied = false;
    public bool dialogueActive = false;
    public bool dialogueEnded = false;
    public bool outOfRange = true;

    public bool IsQuestin = false;
    private bool test = false;
    private bool answerCheck = false;

    public AudioClip audioClip;
    AudioSource audioSource;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        dialogueText.text = "";
        Cursor.visible = true;
    }

    void Update()
    {
        //Press the space bar to apply no locking to the Cursor
        //if (Input.GetKey(KeyCode.Space))
        //    Cursor.lockState = CursorLockMode.None;
        //currentButtonName1 = ButtonClick.CurrentButtonName;
        //AnswersPlayer[ButtonClick.CurrentButtonClick] = ButtonClick.CurrentButtonName;
    }

    //void OnGUI()
    //{
    //    //Press this button to lock the Cursor
    //    if (GUI.Button(new Rect(0, 0, 100, 50), "Lock Cursor"))
    //    {
    //        Cursor.lockState = CursorLockMode.Locked;
    //    }

    //    //Press this button to confine the Cursor within the screen
    //    if (GUI.Button(new Rect(125, 0, 100, 50), "Confine Cursor"))
    //    {
    //        Cursor.lockState = CursorLockMode.Confined;
    //    }
    //}

    public void EnterRangeOfNPC()
    {
        outOfRange = false;
        dialogueGUI.SetActive(true);
        if (dialogueActive == true)
        {
            dialogueGUI.SetActive(false);  //wenn andere Dialog geöffnet ist, dann schließen
        }
    }

    public void NPCName()
    {
        outOfRange = false;
        Cursor.lockState = CursorLockMode.None;
        //if (dialogueQuestions[currentQuestionIndex])
        //{
        //    dialogueBoxGUIQuestion.gameObject.SetActive(true);
        //    //dialogueBoxGUI.gameObject.SetActive(false);

        //    //dialogueGUI.SetActive(false);
        //    //dialogueBoxGUI.gameObject.SetActive(false);
        //}
        //else
        //{
        //    dialogueBoxGUI.gameObject.SetActive(true);
        //    dialogueBoxGUIQuestion.gameObject.SetActive(false);
        //}

        dialogueGUI.SetActive(false);
        dialogueBoxGUI.gameObject.SetActive(true);

        nameText.text = Names;
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!dialogueActive)
            {
                dialogueActive = true;
                StartCoroutine(StartDialogue());
            }
        }
        StartDialogue();
        //currentQuestionIndex++;
    }



    private IEnumerator StartDialogue()
    {
        if (outOfRange == false)
        {
            int dialogueLength = dialogueLines.Length;
            currentDialogueIndex = 0;
           
            
            while (currentDialogueIndex < dialogueLength || !letterIsMultiplied)
            {
                if (!letterIsMultiplied)
                {
                    letterIsMultiplied = true;
                    StartCoroutine(DisplayString(dialogueLines[currentDialogueIndex++]));
                    if (dialogueQuestions[currentDialogueIndex-1])
                    {
                        currentQuestionIndex++;
                        if(!answerCheck)
                        {
                            dialogueBoxGUIQuestionButtons.gameObject.SetActive(true);
                        }
                        if (answerCheck)
                        {
                            dialogueBoxGUIQuestionButtons.gameObject.SetActive(false);
                            //NPCName();
                            break;
                        }
                        //dialogueBoxGUIQuestionButtons.gameObject.SetActive(true);

                    }
                    else
                    {
                        dialogueBoxGUIQuestionButtons.gameObject.SetActive(false);
                    }
                    if (currentDialogueIndex >= dialogueLength)
                    {
                        dialogueEnded = true;
                    }
                }
                yield return 0;
            }

            while (true)
            {
                if (Input.GetKeyDown(DialogueInput) && dialogueEnded == false)
                {
                    break;
                }
                yield return 0;
            }
            dialogueEnded = false;
            dialogueActive = false;
            DropDialogue();
            //currentQuestionIndex = 0;
        }
    }





    private IEnumerator DisplayString(string stringToDisplay)
    {
        if (outOfRange == false)
        {
            int stringLength = stringToDisplay.Length;
            int currentCharacterIndex = 0;

            dialogueText.text = "";
            IsQuestin = false;

            while (currentCharacterIndex < stringLength)
            {
                dialogueText.text += stringToDisplay[currentCharacterIndex];
                currentCharacterIndex++;

                //if (stringToDisplay.EndsWith("?") == true)
                //{
                //    IsQuestin = true;
                //}

                if (currentCharacterIndex < stringLength)
                {
                    if (Input.GetKey(DialogueInput))
                    {
                        yield return new WaitForSeconds(letterDelay * letterMultiplier);
                        
                        if (audioClip) audioSource.PlayOneShot(audioClip, 0.5F);

                    }
                    else
                    { 
                    
                        yield return new WaitForSeconds(letterDelay);

                        if (audioClip) audioSource.PlayOneShot(audioClip, 0.5F);
                    }
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                if (Input.GetKeyDown(DialogueInput))
                {
                    break;
                }
                yield return 0;
            }
            dialogueEnded = false;
            letterIsMultiplied = false;
            dialogueText.text = "";
        }
    }

    public void DropDialogue()
    {       
        dialogueGUI.SetActive(false);
        dialogueBoxGUI.gameObject.SetActive(false);
        dialogueBoxGUIQuestionButtons.gameObject.SetActive(false);
    }

    public void OutOfRange()
    {
        outOfRange = true;
        if (outOfRange == true)
        {
            letterIsMultiplied = false;
            dialogueActive = false;
            StopAllCoroutines();
            dialogueGUI.SetActive(false);
            dialogueBoxGUI.gameObject.SetActive(false);
            dialogueBoxGUIQuestionButtons.gameObject.SetActive(false);
        }
    }

    public void DialogueBoxButtonSetActiveFalse()
    {
        dialogueBoxGUIQuestionButtons.gameObject.SetActive(false);
    }
    public void CheckAnswerCheck(bool answercheck1)
    {
        answerCheck = answercheck1;
    }

}
