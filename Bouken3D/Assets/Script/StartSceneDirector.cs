using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneDirector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartButtonDown()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
