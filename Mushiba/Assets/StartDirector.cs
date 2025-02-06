using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;

public class StartDirector : MonoBehaviour
{
    public AudioClip startButtonPush;
    public AudioClip startBGM;
    AudioSource aud;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(null, new Vector2(400, 160), CursorMode.ForceSoftware);
        this.aud = GetComponent<AudioSource>();
        this.aud.Play();

    }

    public void StartButtonDown() {
        this.aud.PlayOneShot(this.startButtonPush);
        SceneManager.LoadScene("GameScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
