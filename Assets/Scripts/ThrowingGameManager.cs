using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThrowingGameManager : MonoBehaviour
{
    // �I���Ă��������Ă��邩���擾�������̂ŁA�I���ẴR���|�[�l���g���Q�Ƃ�����
    public ThrowingTarget[] throwingTargets = new ThrowingTarget[2];
    // 60�b�o�������𔻒肵�����̂�VRtimer�̃R���|�[�l���g���Q�Ƃ����܂��B
    public VRTimer VRTimer;

    public TextMeshPro ResultText;

    private int clearCount = 0;

    private bool gameClear = false;

    private void Start()
    {
        ResultText.text = string.Empty;
        clearCount = throwingTargets.Length;
    }
    private void Update()
    {
        if (gameClear)
        {
            return;
        }

        // ���Ԑ؂�
        if (VRTimer.GetLimitTime == 0f)
        {
            ResultText.text = "Game Over!";
            VRTimer.TimerStop = true;
            gameClear = true;
        }

        for (int i = 0; i < throwingTargets.Length; i++)
        {
            if (throwingTargets[i].IsClear)
            {
                clearCount++;
            }
            else
            {
                clearCount--;
            }

            // �N���A�̃J�E���g�ƁA�I���Ă��N���A���ꂽ�J�E���g���������ꍇ
            if (clearCount == throwingTargets.Length)
            {
                ResultText.text = "Game Clear!";
                VRTimer.TimerStop = true;
                gameClear = true;
            }

        }
    }
}
