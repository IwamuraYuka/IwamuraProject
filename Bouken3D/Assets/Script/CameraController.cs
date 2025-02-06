using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float yOffset=1.7f; // y軸方向のオフセット
    float zOffset=-2.5f;// z軸方向のオフセット
    float xturnOffset = -1f;
    float zturnOffset = -2.5f;
    GameObject player;
   



    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Gecko");
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        float z = player.transform.position.z;
        float rotY = player.transform.localEulerAngles.y;


        transform.position = new Vector3(x, y + yOffset, z + zOffset);
        Debug.Log("rotY:" + rotY);

        //プレイヤのrotationYが10以上100未満の場合
        if (360>rotY && rotY >270) {
            
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotY, 0);
        }
        else if(50 > rotY && rotY >0)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotY, 0);
        }
        else
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, 0);
        }

        //if(rotY>-90)


       /* if (rotY > 30)
        {
            Debug.Log("プレイヤー回転検知");
            transform.position = new Vector3(x + xturnOffset, y + yOffset, z + zturnOffset);
            transform.Rotate(new Vector3(x,(rotY / 3),z));

        }
        else
        {
            transform.position = new Vector3(x, y + yOffset, z + zOffset);
        }
       

       / transform.rotation = player.transform.rotation;

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = player.transform.rotation;
             //Vector3 zcamera = new Vector3(x,y+yOffset+z+z);
            //transform.position = player.transform.position.z+5;
            //transform.eulerAngles = new Vector3(0,180, 0);
        };*/

    }
}
