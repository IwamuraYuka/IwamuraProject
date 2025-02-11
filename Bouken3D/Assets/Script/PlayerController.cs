using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float jumpForce = 300.0f;
    float walkForce;
    float dashForce = 10.0f;
    Rigidbody rigidBody;
    Animator animator;
    private bool isJumping;
    public AudioClip walkSound;
    public AudioClip jumpSound;
    public AudioClip damage;
    AudioSource audioSource;


    //Joystick設定
    private Vector3 m_Direction;
    [SerializeField] VariableJoystick vj;
    private float c = 2.0f;

    // 回転速度
    public float rotationSpeed = 5.0f;




    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigidBody = GetComponent<Rigidbody>();
        this.animator = GetComponent<Animator>();
        this.audioSource = GetComponent<AudioSource>();
        isJumping = false;
        animator.SetBool("death", false);
        animator.SetBool("eyes_Dead", false);

    }

    void Update()
    {
        //通常の歩く速度
        this.walkForce = 3.0f;


        //ゲーム開始してからプレイヤー操作可能
        if (GameController.startTime < 0 && !EnemyContoroller.attack)
        {
            if (!isJumping)
            {
                PlayerMovePC();
                PlayerMoveMoba();
            }

            if(Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                Jump();
            }

            if (Input.GetKey(KeyCode.DownArrow) && isJumping)
            {
                this.rigidBody.AddForce(-transform.forward * 10.0f);
            }

            if (isJumping && vj.Vertical < 0)
            {
                Debug.Log("減力発動");
                this.rigidBody.AddForce(-transform.forward * 10.0f);
            }
        }

        //攻撃を受けたらゲームオーバー
        if (EnemyContoroller.attack)
        {
            rigidBody.velocity = Vector3.zero;
            Death();

        }
        
    }

    private void rotationMax()
    {
        if (this.transform.localEulerAngles.y > 180)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    //プレイヤーの動き
    private void PlayerMovePC()
    {

        animator.SetBool("walk", false);
        animator.SetBool("jump", false);

        //ダッシュ(Shiftが押されている間)
        if (Input.GetKey(KeyCode.LeftShift))
        {
            this.walkForce = dashForce;

        }

        //////////メインカメラがオンの場合
        if (CameraSwitcher.mainOn)
        {
            //前へ移動
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {

                //歩くアニメーションを再生
                animator.SetBool("walk", true);
                rigidBody.velocity = transform.forward * walkForce;
                transform.Rotate(new Vector3(0, 0, 0));

            }

            //後ろを向く
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {

                animator.SetBool("walk", true);
                transform.eulerAngles = new Vector3(0, 180, 0);
                rigidBody.velocity = transform.forward * walkForce;

            }

            // 右へ移動 
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {

                animator.SetBool("walk", true);
                transform.Rotate(new Vector3(0, 20, 0) * Time.deltaTime);


            }

            // 左へ移動
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                animator.SetBool("walk", true);
                transform.Rotate(new Vector3(0, -20, 0) * Time.deltaTime);


            }
        }//////////サブカメラがオンの場合
        else
        {
            //前へ移動
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                //歩くアニメーションを再生
                animator.SetBool("walk", true);
                rigidBody.velocity = transform.forward * walkForce;

                if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    rigidBody.velocity = transform.forward * walkForce;
                }
            }

            //後ろを向く
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {

                animator.SetBool("walk", true);
                transform.eulerAngles = new Vector3(0, 0, 0);
                rigidBody.velocity = transform.forward * walkForce;

            }

            // 右へ移動 
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {

                animator.SetBool("walk", true);
                transform.Rotate(new Vector3(0, -20, 0) * Time.deltaTime);


            }

            // 左へ移動
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                animator.SetBool("walk", true);
                transform.Rotate(new Vector3(0, 20, 0) * Time.deltaTime);


            }
        }

        //移動時にオーディオ再生
        if (Input.GetKey(KeyCode.LeftArrow) ||
                Input.GetKey(KeyCode.RightArrow) ||
                Input.GetKey(KeyCode.UpArrow))
        {
            audioSource.PlayOneShot(walkSound);
        }

    }


    private void PlayerMoveMoba()
    {
        // ジョイスティックの操作
        m_Direction = new Vector3(vj.Horizontal, 0, vj.Vertical);

        if (m_Direction.magnitude > 0.1f)
        {
            // アニメーションを再生
            animator.SetBool("walk", true);
            animator.SetBool("jump", false);

            // 移動速度の設定
            rigidBody.velocity = m_Direction.normalized * dashForce;

            // 移動方向に滑らかに回転
            Quaternion targetRotation = Quaternion.LookRotation(m_Direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
        else
        {
            // ジョイスティックが入力されていない場合
            if (!Input.anyKey)
            {
                animator.SetBool("walk", false);
                animator.SetBool("jump", false);
            }
        }
    }

    public void Jump()
    {
        //ジャンプする

        //rigidBody.constraints = RigidbodyConstraints.None;
        if (!isJumping)
        {
            Debug.Log("ジャンプ");
            this.rigidBody.AddForce(transform.up * this.jumpForce);
            animator.SetBool("walk", false);
            animator.SetBool("jump", true);
            audioSource.PlayOneShot(jumpSound);

        }

    }

        private void OnCollisionEnter(Collision collision)
        {
            //地面と接していたらジャンプ
            if (collision.gameObject.tag == "Terrain")
            {
            Debug.Log("地面と接している");
                isJumping = false;
                

            }

        }

        private void OnCollisionExit(Collision collision)
        {
            //地面から離れている間はジャンプ禁止
            if (collision.gameObject.name == "Terrain")
            {
                Debug.Log("地面と離れている");
                isJumping = true;
            }
        }

      


        private void Death()
        {
            //アニメーション再生
            animator.SetBool("walk", false);
            animator.SetBool("jump", false);
            animator.SetBool("death", true);
            animator.SetBool("eyes_Dead", true);
            animator.SetTrigger("eyes_Death_Trigger");
            Debug.Log("ゲームオーバー");
        }
            
        
    } 


