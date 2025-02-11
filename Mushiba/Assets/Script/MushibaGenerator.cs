using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushibaGenerator : MonoBehaviour
{
    public GameObject Prefab_Mushiba;
    public GameObject Prefab_Maou;
    public Sprite kirakira;
    GameObject gameDirector;
    float delta = 0;
    float deltaMaou = 0;
    float delete = 0;
    float deleteM = 0;


    void Start()
    {
        Cursor.SetCursor(null, new Vector2(0, 0), CursorMode.ForceSoftware);
    }

    void Update()
    {
        this.delta += Time.deltaTime;
        this.deltaMaou += Time.deltaTime;
        this.delete += Time.deltaTime;
        this.deleteM += Time.deltaTime;

        gameDirector = GameObject.Find ( "GameDirector" );
        float startTime = GameDirector.startTime;

        if (startTime < 0.0f) {

            if (this.delta > 0.5f)
            {
                this.delta = 0;
                GameObject go = Instantiate(Prefab_Mushiba);
                int px = Random.Range(-7, 6);
                int py = Random.Range(2, -2);
                go.transform.position = new Vector3(px, py, 0);
                Destroy(go, 1.0f);

            }
        }

        if (this.deltaMaou > 7.0f)
        {
            
            this.deltaMaou = 0;
            GameObject maou = Instantiate(Prefab_Maou);
            int px = Random.Range(-7, 6);
            int py = Random.Range(2, -2);
            maou.transform.position = new Vector3(px, py, 0);
            Destroy(maou, 0.5f);

        }
    }
}
