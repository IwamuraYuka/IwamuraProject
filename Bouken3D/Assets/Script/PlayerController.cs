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


    //Joystick�ݒ�
    private Vector3 m_Direction;
    [SerializeField] VariableJoystick vj;
    private float c = 2.0f;





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
        //�ʏ�̕������x
        this.walkForce = 3.0f;


        //�Q�[���J�n���Ă���v���C���[����\
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
                Debug.Log("���͔���");
                this.rigidBody.AddForce(-transform.forward * 10.0f);
            }
        }

        //�U�����󂯂���Q�[���I�[�o�[
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

    //�v���C���[�̓���
    private void PlayerMovePC()
    {

        animator.SetBool("walk", false);
        animator.SetBool("jump", false);

        //�_�b�V��(D��������Ă����)
        if (Input.GetKey(KeyCode.LeftShift))
        {
            this.walkForce = dashForce;

        }

        //////////���C���J�������I���̏ꍇ
        if (CameraSwitcher.mainOn)
        {
            //�O�ֈړ�
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {

                //�����A�j���[�V�������Đ�
                animator.SetBool("walk", true);
                rigidBody.velocity = transform.forward * walkForce;
                transform.Rotate(new Vector3(0, 0, 0));

                /*if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    transform.Rotate(new Vector3(0, 0, 0));
                    rigidBody.velocity = transform.forward * walkForce;
                }*/
            }

            //��������
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {

                animator.SetBool("walk", true);
                transform.eulerAngles = new Vector3(0, 180, 0);
                rigidBody.velocity = transform.forward * walkForce;

            }

            // �E�ֈړ� 
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {

                animator.SetBool("walk", true);
                transform.Rotate(new Vector3(0, 20, 0) * Time.deltaTime);


            }

            // ���ֈړ�
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                animator.SetBool("walk", true);
                transform.Rotate(new Vector3(0, -20, 0) * Time.deltaTime);


            }
        }//////////�T�u�J�������I���̏ꍇ
        else
        {
            //�O�ֈړ�
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                //�����A�j���[�V�������Đ�
                animator.SetBool("walk", true);
                rigidBody.velocity = transform.forward * walkForce;

                if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.eulerAngles=new Vector3(0, 180, 0);
                    rigidBody.velocity = transform.forward * walkForce;
                }
            }

            //��������
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {

                animator.SetBool("walk", true);
                transform.eulerAngles = new Vector3(0, 0, 0);
                rigidBody.velocity = transform.forward * walkForce;

            }

            // �E�ֈړ� 
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {

                animator.SetBool("walk", true);
                transform.Rotate(new Vector3(0, -20, 0)*Time.deltaTime);


            }

            // ���ֈړ�
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                animator.SetBool("walk", true);
                transform.Rotate(new Vector3(0, 20, 0) * Time.deltaTime);


            }
        }

        //�ړ����ɃI�[�f�B�I�Đ�
        if (Input.GetKey(KeyCode.LeftArrow) ||
                Input.GetKey(KeyCode.RightArrow) ||
                Input.GetKey(KeyCode.UpArrow))
            {
                audioSource.PlayOneShot(walkSound);
            }

        }

    private void PlayerMoveMoba()
    {
        //joyStick�̑���
        if(vj.Vertical!=0 && vj.Horizontal != 0)
        {
            //�A�j���[�V�������Đ�
            animator.SetBool("walk", true);
            animator.SetBool("jump", false);
            rigidBody.velocity = m_Direction * dashForce;
            transform.localRotation = Quaternion.LookRotation(m_Direction);

            if (CameraSwitcher.mainOn)
            {
                m_Direction = Vector3.forward * vj.Vertical + Vector3.right * vj.Horizontal;
            }
            else
            {
                m_Direction = Vector3.forward * -vj.Vertical + Vector3.right * -vj.Horizontal;  
            }
          
            
            Debug.Log("�o�[�e�B�J��" + vj.Vertical + "�z���C�]������" + vj.Horizontal);
        }
        else
        {
            if (!Input.anyKey)
            {
                animator.SetBool("walk", false);
                animator.SetBool("jump", false);
            }

           
        }


    }

    public void Jump()
    {
        //�W�����v����

        //rigidBody.constraints = RigidbodyConstraints.None;
        if (!isJumping)
        {
            Debug.Log("�W�����v");
            this.rigidBody.AddForce(transform.up * this.jumpForce);
            animator.SetBool("walk", false);
            animator.SetBool("jump", true);
            audioSource.PlayOneShot(jumpSound);

        }

    }

        private void OnCollisionEnter(Collision collision)
        {
            //�n�ʂƐڂ��Ă�����W�����v
            if (collision.gameObject.tag == "Terrain")
            {
            Debug.Log("�n�ʂƐڂ��Ă���");
                isJumping = false;
                

            }

        }

        private void OnCollisionExit(Collision collision)
        {
            //�n�ʂ��痣��Ă���Ԃ̓W�����v�֎~
            if (collision.gameObject.name == "Terrain")
            {
                Debug.Log("�n�ʂƗ���Ă���");
                isJumping = true;
            }
        }

      


        private void Death()
        {
            //�A�j���[�V�����Đ�
            animator.SetBool("walk", false);
            animator.SetBool("jump", false);
            animator.SetBool("death", true);
            animator.SetBool("eyes_Dead", true);
            animator.SetTrigger("eyes_Death_Trigger");
            Debug.Log("�Q�[���I�[�o�[");
        }
            
        
    } 


