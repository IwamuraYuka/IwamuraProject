using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameDirector : MonoBehaviour
{
    GameObject musibakin;
    GameObject DeleteManager;
    public GameObject shadow;
    public float countDown = 30.0f;
    public static float startTime=4.0f;
    public TextMeshProUGUI StartTimeTMP;
    public TextMeshProUGUI timeTMP;
    AudioSource aud;

   
    void Start()
    {
        this.aud = GetComponent<AudioSource>();
        this.musibakin = GameObject.Find("Prefab_Mushiba");
        this.DeleteManager = GameObject.Find("DeleteManager");
        startTime = 4.0f;
        countDown = 30.0f;
    }

    
    void Update()
    {

        startTime -= Time.deltaTime;
        int startTimeInt = (int)startTime;
        StartTimeTMP.text = startTimeInt.ToString();

        if (startTimeInt==0)
        {
            Destroy(this.StartTimeTMP);
            Destroy(shadow);
        }
        

        if (startTimeInt < -1)
        {
            this.aud.Play();
            countDown -= Time.deltaTime;
            int countDownInt = (int)countDown;
            timeTMP.text = "残り時間:" + countDownInt + "秒".ToString();

            if (countDownInt == 0)
            {
                timeTMP.text = "終了！";
                SceneManager.LoadScene("ClearScene");
            }
        } 
     
        
    }
}
