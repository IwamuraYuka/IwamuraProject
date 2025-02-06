using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    void Start()
    {
        //スタート時に敵を5体生成
        for (int i = 0; i < 5; i++)
        {

            
                GameObject item = Instantiate(enemyPrefab);
                item.transform.position = new Vector3(50, 0, 10);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
