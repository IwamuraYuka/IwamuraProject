using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CautionAreaChecker : MonoBehaviour
{
    public bool invaded =false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // �G�L�����̌��o�͈͂ɓ������ꍇ
        if (other.gameObject.name == "Gecko")
        {
            Debug.Log("�͈͓��ɂ���");
            invaded = true; // �͈͓��ɂ��邱�Ƃ��L�^
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // �G�L�����̌��o�͈͂���o���ꍇ
        if (other.gameObject.name == "Gecko")
        {
            Debug.Log("�͈͊O�ɂ���");
            invaded=false; // �͈͊O�ɂ��邱�Ƃ��L�^
        }
    }
}
