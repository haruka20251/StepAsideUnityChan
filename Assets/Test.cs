using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    //�A�j���[�V�������邽�߂̃R���|�[�l���g������
    private Animator myAnimator;

    //Unity�������ړ�������R���|�[�l���g������
    private Rigidbody myRigidbody;
    //�O�����̑��x
    private float velocityZ = 16f;
    //�������̑��x
    private float velocityX = 10f;
    //������̑��x
    private float velocityY = 10f;
    //���E�̈ړ��ł���͈�
    private float movableRange = 3.4f;
    //����������������W��
    private float coefficient = 0.99f;
    //�Q�[���I���̔���
    private bool isEnd = false;
    //�Q�[���I�����ɕ\������e�L�X�g
    private GameObject stateText;
    //�X�R�A��\������e�L�X�g
    private GameObject scoreText;
    //���_
    private int score = 0;
    //���{�^�������̔���i�ǉ��j
    private bool isLButtonDown = false;
    //�E�{�^�������̔���i�ǉ��j
    private bool isRButtonDown = false;
    //�W�����v�{�^�������̔���i�ǉ��j
    private bool isJButtonDown = false;

    // Start is called before the first frame update
    void Start()
    {

        

    }


    // Update is called once per frame
    void Update()
    {

        //�Q�[���I���Ȃ�Unity�����̓�������������
        if (this.isEnd)
        {
            this.velocityZ *= this.coefficient;
            this.velocityX *= this.coefficient;
            this.velocityY *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;
        }

        //�������̓��͂ɂ�鑬�x
        float inputVelocityX = 0;
        //������̓��͂ɂ�鑬�x
        float inputVelocityY = 0;


        //Unity��������L�[�܂��̓{�^���ɉ����č��E�Ɉړ�������i�ǉ��j
        if ((Input.GetKey(KeyCode.LeftArrow) || this.isLButtonDown) && -this.movableRange < this.transform.position.x)
        {
            //�������ւ̑��x����
            inputVelocityX = -this.velocityX;
        }
        else if ((Input.GetKey(KeyCode.RightArrow) || this.isRButtonDown) && this.transform.position.x < this.movableRange)
        {
            //�E�����ւ̑��x����
            inputVelocityX = this.velocityX;
        }

        //�W�����v���Ă��Ȃ����ɃX�y�[�X�܂��̓{�^���������ꂽ��W�����v����i�ǉ��j
        if ((Input.GetKeyDown(KeyCode.Space) || this.isJButtonDown) && this.transform.position.y < 0.5f)
        {
            //�W�����v�A�j�����Đ�
            this.myAnimator.SetBool("Jump", true);
            //������ւ̑��x����
            inputVelocityY = this.velocityY;
        }
        else
        {
            //���݂�Y���̑��x����
            inputVelocityY = this.myRigidbody.velocity.y;
        }

        //Jump�X�e�[�g�̏ꍇ��Jump��false���Z�b�g����
        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }

        //Unity�����ɑ��x��^����
        this.myRigidbody.velocity = new Vector3(inputVelocityX, inputVelocityY, velocityZ);
    }


    //�g���K�[���[�h�ő��̃I�u�W�F�N�g�ƐڐG�����ꍇ�̏���
    void OnTriggerEnter(Collider other)
    {

        

    }


    //�W�����v�{�^�����������ꍇ�̏����i�ǉ��j
    public void GetMyJumpButtonDown()
    {
        this.isJButtonDown = true;
    }

    //�W�����v�{�^���𗣂����ꍇ�̏����i�ǉ��j
    public void GetMyJumpButtonUp()
    {
        this.isJButtonDown = false;
    }

    //���{�^���������������ꍇ�̏����i�ǉ��j
    public void GetMyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }
    //���{�^���𗣂����ꍇ�̏����i�ǉ��j
    public void GetMyLeftButtonUp()
    {
        this.isLButtonDown = false;
    }

    //�E�{�^���������������ꍇ�̏����i�ǉ��j
    public void GetMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }
    //�E�{�^���𗣂����ꍇ�̏����i�ǉ��j
    public void GetMyRightButtonUp()
    {
        this.isRButtonDown = false;
    }
}
