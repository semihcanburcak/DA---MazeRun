using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class NPC : MonoBehaviour {

    public Transform ChatBackGround;
    public Transform ChatBackGroundQuestion;
    public Transform NPCCharacter;

    private DialogueSystem dialogueSystem;
    private int currentQuestionIndex;

    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;
    public bool[] IfQuestions;

    void Start () {
        dialogueSystem = FindObjectOfType<DialogueSystem>(); //finds Dialogue System 
    }
	
	void Update () {
          Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
          Pos.y += 175;
          ChatBackGround.position = Pos;
        Vector3 PosQ = Pos;         //Position of the Qestion Buttons
        PosQ.y -= 80;
        PosQ.x += 90;
        ChatBackGroundQuestion.position = PosQ;
    }

    public void OnTriggerStay(Collider other)
    {
        this.gameObject.GetComponent<NPC>().enabled = true;
        FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();
        //dialogueSystem.currentDialogueIndex = dialogueindex;
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences;
            dialogueSystem.dialogueQuestions = IfQuestions;
            //dialogueSystem.currentQuestionIndex = currentQuestionIndex;
            FindObjectOfType<DialogueSystem>().NPCName();
        }
    }

    public void OnTriggerExit()
    {
        FindObjectOfType<DialogueSystem>().OutOfRange();
        this.gameObject.GetComponent<NPC>().enabled = false;
    }
}

