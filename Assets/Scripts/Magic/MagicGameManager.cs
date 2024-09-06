using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicGameManager : MonoBehaviour
{
    private VRTimer vRTimer;

    private ScoreManager scoreManager;

    public GameObject BoxTarget;

    private int boxNum = 6;

    private void Start()
    {
        vRTimer = FindAnyObjectByType<VRTimer>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
        for (int i = 0; i < boxNum; i++)
        {
            var box = Instantiate(BoxTarget);
            var positionX = Random.Range(-5, 5);
            var positionY = Random.Range(0, 5);
            box.transform.position = new Vector3(positionX, positionY, 3);
        }
    }

    private void Update()
    {
        if (vRTimer.GetLimitTime <= 0f)
        {
            vRTimer.TimerStop = true;
            vRTimer.HideText();
            scoreManager.ViewScore();
        }
    }
}
