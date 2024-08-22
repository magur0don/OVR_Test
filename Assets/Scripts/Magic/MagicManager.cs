using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicManager : MonoBehaviour
{
    //�@ public�C���q��GameObect�^�̕ϐ�MagicObject���쐬���܂��B
    public GameObject MagicObject;

    public Transform RightHand = null;

    public Vector3 forwradOffset = new Vector3(-0.4f,0,0);

    //�A public void�^��GameObject��SetActive��true�ɂ���C�ӂ̖��O�̃��\�b�h���쐬����
    public void MagicActive()
    {
        if (RightHand != null)
        {
            MagicObject.transform.parent = RightHand;
            MagicObject.transform.localPosition = forwradOffset;
        }

        MagicObject.SetActive(true);
    }

    //�B public void�^��GameObject��SetActive��false�ɂ���C�ӂ̖��O�̃��\�b�h���쐬����
    public void MagicDeactivate()
    {
        MagicObject.SetActive(false);
    }

}
