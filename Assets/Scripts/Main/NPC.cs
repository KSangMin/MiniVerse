using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public string npcName;
    public Sprite npcSprite;
    public List<string> dialogue = new List<string>();

    public override void Interact()
    {
        if (!DialogueManager.Instance.isDialogueStarted)
        {
            DialogueManager.Instance.StartDialogue(this);
        }
    }
}
