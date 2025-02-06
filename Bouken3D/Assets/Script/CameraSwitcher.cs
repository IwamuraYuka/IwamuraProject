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
        //�J�����ꎞ�؂�ւ�
       /* if (Input.GetKeyDown(KeyCode.V))
        {
            BackCamera();
        }

        if (Input.GetKeyUp(KeyCode.V))
        {
            BackCamera();
        }*/

        //�J�������S�؂�ւ�
        if (Input.GetKey(KeyCode.C))
        {
            SwitchCamera();
        }
    }

    public void SwitchCamera()
    {
        if (mainOn)
        {
            //Sub�J�������A�N�e�B�u�ɐݒ�
            mainCamera.enabled = false;
            subCamera.enabled = true;
            mainOn = false;
            Debug.Log("�T�u�J�����I��");
        }
        else
        {
            //Main�J�������A�N�e�B�u�ɐݒ�
            mainCamera.enabled = true;
            subCamera.enabled = false;
            mainOn = true;
            Debug.Log("���C���J�����I��");
        }
    }

    public void BackCamera()
    {
        if (mainOn)
        {
            //Sub�J�������A�N�e�B�u�ɐݒ�
            mainCamera.enabled = false;
            subCamera.enabled = true;
            mainOn = false;
            Debug.Log("�T�u�J�����I��");
        }
        else
        {
            //Main�J�������A�N�e�B�u�ɐݒ�
            mainCamera.enabled = true;
            subCamera.enabled = false;
            mainOn = false;
            Debug.Log("���C���J�����I��");
        }
    }


    /*//�{�^���̐���
    public void CameraButtonDown()
    {
            //Sub�J�������A�N�e�B�u�ɐݒ�
            mainCamera.enabled = false;
            subCamera.enabled = true;
            //mainOn = false;
            Debug.Log("�T�u�J�����I��");
       
    }

    public void CameraButtonUp()
    {

        //Main�J�������A�N�e�B�u�ɐݒ�
        mainCamera.enabled = true;
        subCamera.enabled = false;
        //mainOn = true;
        Debug.Log("���C���J�����I��");

    }*/

}
    


/*  //����󂪉�����Ă���ԁA�T�u�J�������A�N�e�B�u�ɂ���
            if (mainOn&&!subOn)
            {
                if (Input.GetKey(KeyCode.DownArrow))
            
                {
                    //sub�J�������A�N�e�B�u�ɐݒ�
                    mainCamera.enabled = false;
                    subCamera.enabled = true;
                    mainOn = false;
                    Debug.Log("�T�u�J�����I��");
                 }
           
            }
            if (!mainOn&&subOn) {
 
            if (Input.GetKey(KeyCode.DownArrow))

            {
                //sub�J�������A�N�e�B�u�ɐݒ�
                mainCamera.enabled = true;
                subCamera.enabled = false;
                mainOn = true;
                Debug.Log("���C���J�����I��");
            }

        }

        /*if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            subOn = true;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && subOn)
        {
            //main�J�������A�N�e�B�u�ɐݒ�
            mainCamera.enabled = true;
            subCamera.enabled = false;
            mainOn = true;
            
            Debug.Log("���C���J�����I��");
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            subOn = false;
            
        }*/
