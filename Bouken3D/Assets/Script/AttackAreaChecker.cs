using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAreaChecker : MonoBehaviour
{
    public bool invaded = false;
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
            invaded = true;
        }
  }


}
