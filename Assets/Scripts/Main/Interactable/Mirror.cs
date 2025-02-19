using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : Interactable
{
    public override void Interact()
    {
        AvatarManager.Instance.TurnOnAvatar();
    }
}
