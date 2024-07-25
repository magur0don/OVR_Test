using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuzzleUIManager : MonoBehaviour
{
    // �@public TextmeshPro型の変数でReturnCountTextMeshを作成する。

    public TextMeshPro ReturnCountTextMesh;
    // �Apublic PuzzleGameManager型でPuzzleGameManagerという変数を作成する。
    public PuzzleGameManager PuzzleGameManager;
    // Update内でPuzzleGameManagerのGetReturnCountをGetReturnCount/3という形で表示する

    private void Update()
    {
        ReturnCountTextMesh.text = $"{PuzzleGameManager.GetReturnCount}/3";
    }
}
