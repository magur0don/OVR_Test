using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ReturnObject : MonoBehaviour
{

    public PuzzleGameManager PuzzleGameManager;

    /// <summary>
    /// �������g��Collider
    /// </summary>
    private Collider myCollider = null;

    /// <summary>
    /// �X�i�b�v������
    /// </summary>
    private bool isSnapped = false;

    /// <summary>
    /// �X�i�b�v�����Ƃ��̃G�t�F�N�g
    /// </summary>
    public ParticleSystem SnappedEffect;

    private void Start()
    {
        myCollider = GetComponent<Collider>();
    }

    /// <summary>
    /// �N�����̔���
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        // ���łɃX�i�b�v����Ă�����ȉ��̏����͂��Ȃ�
        if (isSnapped) 
        {
            return;
        }

        // �����Aother�I�u�W�F�N�g�̈�ԊO���̓_�i�ő�̓_�j��myCollider�̒��ɂ���A
        // ���Aother�I�u�W�F�N�g�̈�ԓ����̓_�i�ŏ��̓_�j��myCollider�̒��ɂ���Ȃ�A
        // �܂�Aother�I�u�W�F�N�g�S�̂�myCollider�̒��ɓ����Ă��邱�Ƃ��Ӗ����܂��B 
        if (myCollider.bounds.Contains(other.bounds.max)&&
            myCollider.bounds.Contains(other.bounds.min))
        {
            // �A�N�����Ă���GameObject��Position,Rotation���A������Position,Rotation�ő������
            other.gameObject.transform.position = this.gameObject.transform.position;
            other.gameObject.transform.rotation = this.gameObject.transform.rotation;
            // �B�N�����Ă���GameObject��RigidBody���擾���A
            // useGravity���I�t�ɂ��āAIsKinematic���I���ɂ���B
            var otherRigidbody = other.gameObject.GetComponent<Rigidbody>();
            otherRigidbody.useGravity = false;
            otherRigidbody.isKinematic = true;

            // �C������MeshRenderer��enabled���I�t�ɂ���
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            PuzzleGameManager.Return();
            isSnapped = true;

            // �G�t�F�N�g���v���C����
            SnappedEffect.Play();
        }
    }
}