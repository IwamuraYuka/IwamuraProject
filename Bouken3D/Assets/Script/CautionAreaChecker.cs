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
        // 敵キャラの検出範囲に入った場合
        if (other.gameObject.name == "Gecko")
        {
            Debug.Log("範囲内にいる");
            invaded = true; // 範囲内にいることを記録
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 敵キャラの検出範囲から出た場合
        if (other.gameObject.name == "Gecko")
        {
            Debug.Log("範囲外にいる");
            invaded=false; // 範囲外にいることを記録
        }
    }
}
