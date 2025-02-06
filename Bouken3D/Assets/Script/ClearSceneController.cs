using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ReturnStartWindowClear()
    {
        SceneManager.LoadScene("StartScene");
    }
    void Update()
    {
        
    }
}
