using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingTarget : MonoBehaviour
{
    // �@OnTrigerEnter���g���ĐN��������擾����B
    // �A��L���\�b�h�̒��ŁA������MeshRenderer����}�e���A���̐F���擾���A�ԐF��������
    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
