using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicManager : MonoBehaviour
{
    //�@ public�C���q��GameObect�^�̕ϐ�MagicObject���쐬���܂��B
    public GameObject MagicObject;

    // ���E���Transform
    public Transform RightHand = null;

    // ���I�t�Z�b�g(�����̍���)
    public Vector3 OffsetPosition = Vector3.zero;
    public Vector3 OffsetEulerAngles= Vector3.zero;

    //�A public void�^��GameObject��SetActive��true�ɂ���C�ӂ̖��O�̃��\�b�h���쐬����
    public void MagicActive()
    {
        if (RightHand != null)
        {
            // MagicObject��RightHand�̈ʒu�ɍ��킹�Ĕz�u���A�I�t�Z�b�g�����f������
            MagicObject.transform.position = RightHand.position + OffsetPosition;
            // ��]��RightHand�ɒǏ]������
            MagicObject.transform.rotation = RightHand.rotation;
            // ��]�l�̃I�t�Z�b�g�𔽉f������
            MagicObject.transform.eulerAngles += OffsetEulerAngles;
        }
        MagicObject.SetActive(true);
    }

    //�B public void�^��GameObject��SetActive��false�ɂ���C�ӂ̖��O�̃��\�b�h���쐬����
    public void MagicDeactivate()
    {
        MagicObject.SetActive(false);
    }

}
