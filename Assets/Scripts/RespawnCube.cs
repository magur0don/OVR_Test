using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCube : MonoBehaviour
{
    // �@Vector3�^��CurrentPos�Ƃ����ϐ���錾���Ă��������B
    Vector3 CurrentPos;

    // Start is called before the first frame update
    void Start()
    {
        // �AgameObject��Transform��Position��CurrentPos�ɑ�����܂��B
        CurrentPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // �B�����AgameObject��Transform��Position��y��������-2f��艺�������
        if (gameObject.transform.position.y < -2f)
        {
            // �CgameObject��Transform��Position��CurrentPos�ő������
            gameObject.transform.position = CurrentPos;
        }
    }
}
