using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuzzleUIManager : MonoBehaviour
{
    // �@public TextmeshPro�^�̕ϐ���ReturnCountTextMesh���쐬����B

    public TextMeshPro ReturnCountTextMesh;
    // �Apublic PuzzleGameManager�^��PuzzleGameManager�Ƃ����ϐ����쐬����B
    public PuzzleGameManager PuzzleGameManager;
    // Update����PuzzleGameManager��GetReturnCount��GetReturnCount/3�Ƃ����`�ŕ\������

    private void Update()
    {
        ReturnCountTextMesh.text = $"{PuzzleGameManager.GetReturnCount}/3";
    }
}
