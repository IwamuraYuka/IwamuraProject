using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera;
    public Camera subCamera;
    public  static bool mainOn;

    void Start()
    {
        mainCamera.enabled = true;
        subCamera.enabled = false;
        mainOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        //カメラ一時切り替え
       /* if (Input.GetKeyDown(KeyCode.V))
        {
            BackCamera();
        }

        if (Input.GetKeyUp(KeyCode.V))
        {
            BackCamera();
        }*/

        //カメラ完全切り替え
        if (Input.GetKey(KeyCode.C))
        {
            SwitchCamera();
        }
    }

    public void SwitchCamera()
    {
        if (mainOn)
        {
            //Subカメラをアクティブに設定
            mainCamera.enabled = false;
            subCamera.enabled = true;
            mainOn = false;
            Debug.Log("サブカメラオン");
        }
        else
        {
            //Mainカメラをアクティブに設定
            mainCamera.enabled = true;
            subCamera.enabled = false;
            mainOn = true;
            Debug.Log("メインカメラオン");
        }
    }

    public void BackCamera()
    {
        if (mainOn)
        {
            //Subカメラをアクティブに設定
            mainCamera.enabled = false;
            subCamera.enabled = true;
            mainOn = false;
            Debug.Log("サブカメラオン");
        }
        else
        {
            //Mainカメラをアクティブに設定
            mainCamera.enabled = true;
            subCamera.enabled = false;
            mainOn = false;
            Debug.Log("メインカメラオン");
        }
    }


    /*//ボタンの制御
    public void CameraButtonDown()
    {
            //Subカメラをアクティブに設定
            mainCamera.enabled = false;
            subCamera.enabled = true;
            //mainOn = false;
            Debug.Log("サブカメラオン");
       
    }

    public void CameraButtonUp()
    {

        //Mainカメラをアクティブに設定
        mainCamera.enabled = true;
        subCamera.enabled = false;
        //mainOn = true;
        Debug.Log("メインカメラオン");

    }*/

}
    


/*  //下矢印が押されている間、サブカメラをアクティブにする
            if (mainOn&&!subOn)
            {
                if (Input.GetKey(KeyCode.DownArrow))
            
                {
                    //subカメラをアクティブに設定
                    mainCamera.enabled = false;
                    subCamera.enabled = true;
                    mainOn = false;
                    Debug.Log("サブカメラオン");
                 }
           
            }
            if (!mainOn&&subOn) {
 
            if (Input.GetKey(KeyCode.DownArrow))

            {
                //subカメラをアクティブに設定
                mainCamera.enabled = true;
                subCamera.enabled = false;
                mainOn = true;
                Debug.Log("メインカメラオン");
            }

        }

        /*if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            subOn = true;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && subOn)
        {
            //mainカメラをアクティブに設定
            mainCamera.enabled = true;
            subCamera.enabled = false;
            mainOn = true;
            
            Debug.Log("メインカメラオン");
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            subOn = false;
            
        }*/
