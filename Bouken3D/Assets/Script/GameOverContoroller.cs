using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverContoroller : MonoBehaviour
{
    public static bool goc = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void ReturnStartWindow()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void Rechallenge()
    {
        SceneManager.LoadScene("GameScene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
