using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UnityChanController : MonoBehaviour
{
    private Animator myAnimator;
    private Rigidbody myRigidbody;
    private float velocityZ = 16f;//�O�����̑���
    private float velocityY = 10f;//�������̑���
    private float velocityX = 10f;//������̑���
    private float movableRange = 3.4f;//���E�̍s���\�͈�
    private float coefficient = 0.99f;//������
    private bool isEnd = false;//�I������(�ϐ��̏����l��false�ɐݒ�,�ŏ�(false)�́u�I�����Ă��Ȃ��v���
    private GameObject stateText;
    private GameObject scoreText;
    private int score = 0;
    //�ȉ��{�^���̕ϐ�
    private bool isLButtonDown = false;
    private bool isRButtonDown = false;
    private bool isJButtonDown= false;
   
    // Start is called before the first frame update
    void Start()
    {
        
        myRigidbody = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
        this.myAnimator.SetFloat("Speed", 1f);//�A�j���[�V�����̎w��
        this.stateText = GameObject.Find("GameResultText");
        this.scoreText = GameObject.Find("ScoreText");

    }
    // Update is called once per frame
    void Update()
    {


        if (this.isEnd)
        {
            this.velocityZ *= this.coefficient;
            this.velocityX *= this.coefficient;
            this.velocityY *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;

        }

        float inputVelocityX = 0;
        float inputVelocityY = 0;

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


    void OnTriggerEnter(Collider other)
    //������Collider�����̃I�u�W�F�N�g��Collider�ƐڐG�������ɌĂ΂��֐�
    {

            if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag")
            {
                this.isEnd = true;
                this.stateText.GetComponent<Text>().text = "GAME OVER";
            }
            if (other.gameObject.tag == "GoalTag")
            {
                this.isEnd = true;
                this.stateText.GetComponent<Text>().text = "CLEAR!";

            }
            if (other.gameObject.tag == "CoinTag")
            {
                this.score += 10;
                this.scoreText.GetComponent<Text>().text = "Score" + this.score + "pt";
                //Play() �� Particle System �N���X�ɗp�ӂ���Ă��郁�\�b�h�ŁA�p�[�e�B�N���̕��o���J�n����
                GetComponent<ParticleSystem>().Play();
                Destroy(other.gameObject);
            }
        
    }
    
    public void GetMyJumpButtonDown()
    {
        this.isJButtonDown = true;
    }
    public void GetMyJumpButtonUp()
    {
        this.isJButtonDown = false;
    }
    public void GetMyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }
    public void GetMyLeftButtonUp()
    {
        this.isLButtonDown= false;
    }
    public void GetMyRightButtonDown()
    {
        this.isRButtonDown= true;
    }
    public void GetMyRightButtonUp()
    {
        this.isRButtonDown= false;
    }
    
   
}
