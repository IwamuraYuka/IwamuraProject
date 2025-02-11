using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCameraController : MonoBehaviour
{
    float yOffset = 1.7f; // y�������̃I�t�Z�b�g
    float zOffset = 2.5f;// z�������̃I�t�Z�b�g
    GameObject player;
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
        transform.position = new Vector3(x, y + yOffset, z +zOffset);
    }
}
