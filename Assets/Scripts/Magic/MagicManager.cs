using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicManager : MonoBehaviour
{
    //‡@ publicCüq‚ÅGameObectŒ^‚Ì•Ï”MagicObject‚ğì¬‚µ‚Ü‚·B
    public GameObject MagicObject;

    public Transform RightHand = null;

    public Vector3 forwradOffset = new Vector3(-0.4f,0,0);

    //‡A public voidŒ^‚ÅGameObject‚ÌSetActive‚ğtrue‚É‚·‚é”CˆÓ‚Ì–¼‘O‚Ìƒƒ\ƒbƒh‚ğì¬‚·‚é
    public void MagicActive()
    {
        if (RightHand != null)
        {
            MagicObject.transform.parent = RightHand;
            MagicObject.transform.localPosition = forwradOffset;
        }

        MagicObject.SetActive(true);
    }

    //‡B public voidŒ^‚ÅGameObject‚ÌSetActive‚ğfalse‚É‚·‚é”CˆÓ‚Ì–¼‘O‚Ìƒƒ\ƒbƒh‚ğì¬‚·‚é
    public void MagicDeactivate()
    {
        MagicObject.SetActive(false);
    }

}
