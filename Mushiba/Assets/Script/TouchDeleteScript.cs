using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TouchDeleteScript : MonoBehaviour
{
    GameObject clickedGameObject;
    public static int deleteNumber;
    public TextMeshProUGUI counterTmp;
    AudioSource aud;
   public AudioClip se;
    public Sprite kirakira;

    // Start is called before the first frame update
    void Start()
    {
        deleteNumber = 0;
        this.aud = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {


            //左クリックをした瞬間にマウスの座標にrayのスタート地点を指定
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //rayを飛ばすコード
            RaycastHit2D hitSprite = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            //rayを飛ばしてオブジェクトに当たったら以下
            if (hitSprite == true)
            {
                //クリックされたゲームオブジェクトを代入
                clickedGameObject = hitSprite.transform.gameObject;

                //もしそのオブジェクトについているタグが"mushibakin"なら消す
                if (clickedGameObject.tag == "musibakin")
                {
                    SpriteRenderer mushiba = clickedGameObject.GetComponent<SpriteRenderer>();
                    mushiba.sprite = kirakira;
                    this.aud.PlayOneShot(this.se);
                    Destroy(clickedGameObject,0.5f);
                    deleteNumber++;
                    counterTmp.text= deleteNumber.ToString();
                    //Debug.Log(deleteNumber);

                }


                //もしそのオブジェクトについているタグが"maou"なら消す
                if (clickedGameObject.tag == "maou")
                {
                    SpriteRenderer maou = clickedGameObject.GetComponent<SpriteRenderer>();
                    maou.sprite = kirakira;
                    this.aud.PlayOneShot(this.se);
                    Destroy(clickedGameObject,0.5f);
                    deleteNumber+=20;
                    counterTmp.text = deleteNumber.ToString();
               

                }

            }
        }
    }
}

