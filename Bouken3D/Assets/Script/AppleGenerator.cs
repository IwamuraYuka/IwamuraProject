using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    void Start()
    {
        //スタート時にランダムな場所にリンゴを8個生成
        for(int i=0; i<8; i++)
        {
            
            float x = Random.Range(-65, 66);
            float z = Random.Range(-55, 56);

            if (x==0&&z==0)
            {
                i--;
                
            }
            else
            {
                GameObject item = Instantiate(applePrefab);
                item.transform.position = new Vector3(x, 0.1f, z);
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
