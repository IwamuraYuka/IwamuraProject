using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera;
    public Camera subCamera;
    public static bool mainOn;

    void Start()
    {
        mainCamera.enabled = true;
        subCamera.enabled = false;
        mainOn = true;
    }

    void Update()
    {
        // カメラを切り替える前に W, A, D キーが押されていないかチェック
        if (Input.GetKeyDown(KeyCode.C) && !IsMovingWithWAD())
        {
            SwitchCamera();
        }
    }

    public void SwitchCamera()
    {
        if (mainOn)
        {
            mainCamera.enabled = false;
            subCamera.enabled = true;
            mainOn = false;
            Debug.Log("サブカメラオン");
        }
        else
        {
            mainCamera.enabled = true;
            subCamera.enabled = false;
            mainOn = true;
            Debug.Log("メインカメラオン");
        }
    }

    // W, A, Dキーが押されているかを判定
    private bool IsMovingWithWAD()
    {
        return Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
    }
}