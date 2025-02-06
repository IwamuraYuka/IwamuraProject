using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleContoroller : MonoBehaviour
{
    public static int get;
    public AudioClip appleGet;
    public static bool appleGetSound;
    private float rotateX =0;
    private float rotateY=10;
    private float rotateZ=0;
    // Start is called before the first frame update
    void Start()
    {
        appleGetSound = false;
        get = 0;
    }

    // Update is called once per frame
    void Update()
    {
        appleGetSound = false;

        //その場で回転
        this.transform.Rotate(new Vector3(rotateX, 90, rotateZ) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーと接触したらポイント加算＆消滅
        if (other.tag == "player")
        {
            Debug.Log("リンゴと接触");
            get++;
            Destroy(this.gameObject);
            appleGetSound = true;

        }

        //ほかの障害物に触れていたら移動する
        if (other.tag == "treeRock")
        {
            Debug.Log("リンゴが障害物に触れていたので移動しました");
            this.transform.position = new Vector3(this.transform.position.x+10,0, this.transform.position.z+10);
        }

        //壁に触れていたら移動する
        if (other.tag == "Terrain")
        {
            Debug.Log("リンゴがterrainに触れていたので移動しました");
            this.transform.position = new Vector3(this.transform.position.x + 10, 0, this.transform.position.z + 10);
        }

    }
}
