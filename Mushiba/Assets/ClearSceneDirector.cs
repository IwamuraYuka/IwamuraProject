using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class ClearSceneDirector : MonoBehaviour
{
    public TextMeshProUGUI resultTMP;
    public TextMeshProUGUI Clear;
    public AudioClip ButtonPush;
    public AudioClip exellent;
    public AudioClip normal;
    public AudioClip failure;
    AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
        this.aud = GetComponent<AudioSource>();
        int result =TouchDeleteScript.deleteNumber;
        Cursor.SetCursor(null, new Vector2(0, 0), CursorMode.ForceSoftware);

        if (result < 60)
        {
            this.aud.PlayOneShot(this.normal);
            Clear.text = "きたないままでした…";
        }

        if (60<result && result < 99)
        {
            this.aud.PlayOneShot(this.exellent);
            Clear.text = "まあまあキレイになりました。";
        }

        resultTMP.text = result+"点".ToString();
    }

    public void StartButtonDown()
    {
        this.aud.PlayOneShot(this.ButtonPush);
        SceneManager.LoadScene("StartScene");
    }

    public void GameButtonDown()
    {
        this.aud.PlayOneShot(this.ButtonPush);
        SceneManager.LoadScene("GameScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
