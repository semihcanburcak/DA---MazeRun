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

    public float letterDelay = 0.1f;
    public float letterMultiplier = 0.5f;
    private int currentDialogueIndex;

    public KeyCode DialogueInput = KeyCode.F;

    public string Names;

    public string[] dialogueLines;
    public bool[] dialogueQuestions;

    public bool letterIsMultiplied = false;
    public bool dialogueActive = false;
    public bool dialogueEnded = false;
    public bool outOfRange = true;

    public bool IsQuestin = false;


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
            dialogueGUI.SetActive(false);
        }
    }

    public void NPCName()
    {
        outOfRange = false;
        Cursor.lockState = CursorLockMode.None;
        if (dialogueQuestions[currentDialogueIndex])
        {
            dialogueBoxGUIQuestion.gameObject.SetActive(true);
            dialogueBoxGUI.gameObject.SetActive(false);

        }
        else
        {
            dialogueBoxGUI.gameObject.SetActive(true);
            dialogueBoxGUIQuestion.gameObject.SetActive(false);

        }
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
    }

    //private bool checkIfQuestion(string dialogue1)
    //{
    //    IsQuestin = false;
    //    if (dialogue1.EndsWith("?") == true)
    //    {
    //        IsQuestin = true;
    //    }
    //    return IsQuestin;
    //}

    private void Question1()
    {

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
           
        }
    }
}
