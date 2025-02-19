using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    public GameObject dlgPanel;
    public Image dlgImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dlgText;

    List<string> _dialogue = new List<string>();

    public bool isDialogueStarted = false;
    bool isInput = false;

    public override void Awake()
    {
        isGlobal = false;

        base.Awake();
    }

    private void Start()
    {
        dlgPanel.SetActive(false);
    }

    public void StartDialogue(NPC npc)
    {
        isDialogueStarted = true;

        dlgImage.sprite = npc.npcSprite;
        nameText.text = npc.npcName;
        _dialogue = npc.dialogue;
        dlgPanel.SetActive(true);

        StartCoroutine(ShowDialogue());
    }

    IEnumerator ShowDialogue()
    {
        foreach(string s in _dialogue)
        {
            dlgText.text = s;
            Debug.Log(s);

            yield return new WaitUntil(() => isInput);
            isInput = false;
        }

        EndDialogue();
    }

    void EndDialogue()
    {
        dlgImage.sprite = null;
        nameText.text = null;
        dlgText.text = null;
        _dialogue = null;
        isInput = false;
        isDialogueStarted = false;

        dlgPanel.SetActive(false);
    }

    public void OnProgress(InputAction.CallbackContext context)
    {
        if (isDialogueStarted)
        {
            if (context.started)
            {
                isInput = true;
            }
        }
    }
}
