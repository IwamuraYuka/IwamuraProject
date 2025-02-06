using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobaPlayerController : MonoBehaviour
{
    [SerializeField] VariableJoystick vj;
    float speed = 10f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = vj.Horizontal;//X�������̓���
        float z = vj.Vertical;//Z�������̓���
        transform.Translate(x * Time.deltaTime * speed, 0, z * Time.deltaTime * speed);//�ړ�
    }
}
