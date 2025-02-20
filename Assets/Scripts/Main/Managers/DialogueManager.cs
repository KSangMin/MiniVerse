using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    public Transform player;

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
        dlgImage.sprite = npc.npcSprite.sprite;
        nameText.text = npc.npcName;
        _dialogue = npc.dialogue;
        dlgPanel.SetActive(true);

        FollowingCamera.Instance.target = npc.transform;
        FollowingCamera.Instance.cam.orthographicSize = 2;

        StartCoroutine(ShowDialogue());
    }

    IEnumerator ShowDialogue()
    {
        yield return new WaitUntil(() => !isInput);

        isDialogueStarted = true;
        isInput = false;

        foreach (string s in _dialogue)
        {
            dlgText.text = s;
            Debug.Log(s);

            yield return new WaitUntil(() => isInput);
            yield return new WaitUntil(() => !isInput);
            isInput = false;
        }

        EndDialogue();
    }

    void EndDialogue()
    {
        FollowingCamera.Instance.target = player.transform;
        FollowingCamera.Instance.cam.orthographicSize = 5;

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
        if (!isDialogueStarted)
        {
            return;
        }

        if (context.started)
        {
            isInput = true;
        }
        else if (context.canceled)
        {
            isInput = false;
        }
    }
}
