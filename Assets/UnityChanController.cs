using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UnityChanController : MonoBehaviour
{
    private Animator myAnimator;
    private Rigidbody myRigidbody;
    private float velocityZ = 16f;//前方向の速さ
    private float velocityY = 10f;//横方向の速さ
    private float velocityX = 10f;//上方向の速さ
    private float movableRange = 3.4f;//左右の行動可能範囲
    private float coefficient = 0.99f;//減速時
    private bool isEnd = false;//終了判定(変数の初期値をfalseに設定,最初(false)は「終了していない」状態
    private GameObject stateText;
    private GameObject scoreText;
    private int score = 0;
    //以下ボタンの変数
    private bool isLButtonDown = false;
    private bool isRButtonDown = false;
    private bool isJButtonDown= false;
   
    // Start is called before the first frame update
    void Start()
    {
        
        myRigidbody = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
        this.myAnimator.SetFloat("Speed", 1f);//アニメーションの指示
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
            //左方向への速度を代入
            inputVelocityX = -this.velocityX;
        }
        else if ((Input.GetKey(KeyCode.RightArrow) || this.isRButtonDown) && this.transform.position.x < this.movableRange)
        {
            //右方向への速度を代入
            inputVelocityX = this.velocityX;
        }

        //ジャンプしていない時にスペースまたはボタンが押されたらジャンプする（追加）
        if ((Input.GetKeyDown(KeyCode.Space) || this.isJButtonDown) && this.transform.position.y < 0.5f)
        {
            //ジャンプアニメを再生
            this.myAnimator.SetBool("Jump", true);
            //上方向への速度を代入
            inputVelocityY = this.velocityY;
        }
        else
        {
            //現在のY軸の速度を代入
            inputVelocityY = this.myRigidbody.velocity.y;
        }

        //Jumpステートの場合はJumpにfalseをセットする
        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }

        //Unityちゃんに速度を与える
        this.myRigidbody.velocity = new Vector3(inputVelocityX, inputVelocityY, velocityZ);
    }


    void OnTriggerEnter(Collider other)
    //自分のColliderが他のオブジェクトのColliderと接触した時に呼ばれる関数
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
                //Play() は Particle System クラスに用意されているメソッドで、パーティクルの放出を開始する
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
