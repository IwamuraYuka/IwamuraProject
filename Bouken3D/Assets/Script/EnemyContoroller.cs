using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;
using Unity.VisualScripting;

public class EnemyContoroller : MonoBehaviour
{
    GameObject player;
    float dashForce = 6.0f; //追いかけてくるときの移動速度
    float walkForce = 3.0f; //徘徊しているときの移動速度
    Animator animator;
    public static bool attack=false;
    Rigidbody rigidBody;
    AudioSource audioSource;
    public AudioClip enemySounds;
    public AudioClip enemyAttack;
    
    public static float  time = 0;

    public CautionAreaChecker cac;
    public AttackAreaChecker aac;

    //NavMeshの設定
    private NavMeshAgent e_navMeshAgent;

    void Start()
    {
        
        this.player = GameObject.Find("Gecko");
        this.animator = GetComponent<Animator>();
        this.rigidBody = GetComponent<Rigidbody>();
        this.audioSource = GetComponent<AudioSource>();

        //NavMeshコンポーネントを取得
        e_navMeshAgent = GetComponent<NavMeshAgent>();

        attack = false;
}

   
    void Update()
    {

        //ゲーム開始してから敵が動き出す
        if (e_navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid&&GameController.startTime < 0)
        {
            //プレイヤが攻撃範囲に入ったら
            if (aac.invaded)
            {
                Attack();
                time += Time.deltaTime;
                if (time>3f)
                {
                    attack = true;
                    rigidBody.velocity = Vector3.zero;
                }
               
            }
            //入っていなかったらランダムな向きに移動
            else
            {
                //移動
                EnemyMove();
            }
                
            
        }

    }

    private void EnemyMove()
    {
        //アニメーションを再生
        animator.SetBool("walkE", true);
        animator.SetBool("attackE", false);

        //検知範囲内にプレイヤが入ったら
        if (cac.invaded)
        {

            // プレイヤーの方向を向く
            e_navMeshAgent.SetDestination(this.player.transform.position);
            // プレイヤーに向かって移動
            rigidBody.velocity = transform.forward * dashForce;
            
        }
        //検知範囲内にプレイヤが入っていなかったら
        else
        {
            //向いている方向へ移動
             rigidBody.velocity = transform.forward * walkForce;
            
            //一定時間を超えた場合目的地を変更
             time += Time.deltaTime;
            if (time > 10.0f)
            {
                //1体目
                if (this.gameObject.name == "enemyPrefab1")
                {
                    Vector3 randomPos1 = randomRange();
                    e_navMeshAgent.SetDestination(randomPos1);
                }

                //2体目
                if (this.gameObject.name == "enemyPrefab1")
                {
                    Vector3 randomPos2 = randomRange();
                    e_navMeshAgent.SetDestination(randomPos2);
                }

                //3体目
                if (this.gameObject.name == "enemyPrefab1")
                {
                    Vector3 randomPos3 = randomRange();
                    e_navMeshAgent.SetDestination(randomPos3);
                }

                //4体目
                if (this.gameObject.name == "enemyPrefab1")
                {
                    Vector3 randomPos4 = randomRange();
                    e_navMeshAgent.SetDestination(randomPos4);
                }

                //5体目
                if (this.gameObject.name == "enemyPrefab5")
                {
                    Vector3 randomPos5 = randomRange();
                    e_navMeshAgent.SetDestination(randomPos5);
                }

                time = 0;


            }

        }
    }
    
    private Vector3 randomRange()
    {
       return  new Vector3(Random.Range(-65, 66), 0, Random.Range(-55, 56));
    }

    private void Attack()
    {
        animator.SetBool("walkE", false);
        animator.SetBool("attackE", true);
    }

    private void OnCollisionStay(Collision collision)
    {
        //木や岩に当たったらまた別の方向へ
        if (collision.gameObject.tag == "treeRock")
        {
            Debug.Log("敵が障害物と接触");
            Vector3 randomPosIrregular=new Vector3(0,90,0);
            transform.Rotate(randomPosIrregular);
            rigidBody.velocity = transform.forward * walkForce;

        }

       
    }


}
 
 
