using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VRTimer : MonoBehaviour
{
    /// <summary>
    /// �b����\������Textmesh
    /// </summary>
    public TextMeshPro TimerTextMesh;
    /// <summary>
    /// ��������
    /// </summary>
    private float limitTime = 30f;

    // limitTime�̃A�N�Z�T
    public float GetLimitTime
    {
        get { return limitTime; }
    }

    /// <summary>
    /// �^�C�}�[�X�g�b�v�p�̃t���O
    /// </summary>
    public bool TimerStop = false;

    // Update is called once per frame
    void Update()
    {
        if (TimerStop)
        {
            return;
        }

        if (limitTime < 0f)
        {
            limitTime = 0f;
        }
        else
        {
            limitTime -= Time.deltaTime;
        }
        TimerTextMesh.text = limitTime.ToString("F2");
    }

    public void HideText()
    {
        TimerTextMesh.gameObject.SetActive(false);
    }
}
