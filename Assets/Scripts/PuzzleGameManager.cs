using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGameManager : MonoBehaviour
{
    // �@private bool�^�̕ϐ���gameClear���쐬���Afalse�ő������B
    private bool gameClear = false;
    // �Apublic bool�^�̕ϐ�GetGameClear(�A�N�Z�T)���쐬���Areturn��gameClear��Ԃ�
    public bool GetGameClear
    {
        get { return gameClear; }
    }

    // �Bprivate int�^�̕ϐ��ŁA���ɖ߂��񐔂Ƃ���returnCount���쐬���A��������3�ōs��
    private int returnCount = 3;

    // �Cpublic int�^�̕ϐ���GetReturnCount(�A�N�Z�T)���쐬���Areturn��returnCount��Ԃ�
    public int GetReturnCount
    {
        get { return returnCount; }
    }
    // �Dpublic void�^��Return()�Ƃ������\�b�h���쐬����B
    public void Return()
    {
        // �E��L���\�b�h�̒��ŌĂ΂ꂽ��returnCount���f�N�������g(-1)����
        returnCount--;
        // �FreturnCount��0�ɂȂ�����AgameClear��true�ɂ���
        if (returnCount <= 0)
        {
            gameClear = true;
        }
    }

}
