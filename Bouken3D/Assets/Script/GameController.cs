using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class GameController : MonoBehaviour
{
    GameObject player;
    GameObject enemy;
    public TextMeshProUGUI pointTMP;
    public TextMeshProUGUI StartTimeTMP;
    public TextMeshProUGUI timeTMP;
    public TextMeshProUGUI GetText;
    public Image shadow;
    public float countDown = 30.0f;
    public static float startTime;


    void Start()
    {
        this.player = GameObject.Find("Gecko");
        this.enemy = GameObject.Find("Enemy");
        startTime = 6.0f;

    }


    void Update()
    {


        this.pointTMP.text = AppleContoroller.get.ToString();

        //ゲーム開始カウントダウン
        startTime -= Time.deltaTime;
        int startTimeInt = (int)startTime;
        StartTimeTMP.text = startTimeInt.ToString();

        //UIを消去
        if (startTimeInt == 0)
        {
            Destroy(this.StartTimeTMP);
            Destroy(this.GetText);
            Destroy(this.shadow);
        }

        //リンゴを5個取得したらクリアシーンへ
        if (AppleContoroller.get == 8)
        {
            Invoke("ChangeClearScene", 1);
        }

        //プレイヤと敵が接触したらゲームオーバーへ
        if (EnemyContoroller.attack)
        {
            Invoke("ChangeGameOver",1);
        }
    }


    public void ChangeClearScene()
    {
        SceneManager.LoadScene("ClearScene");
        Debug.Log("ゲームクリア");
    }

    public void ChangeGameOver()
    {
        SceneManager.LoadScene("GameOverScene");
        Debug.Log("ゲームオーバー");
    }
}
