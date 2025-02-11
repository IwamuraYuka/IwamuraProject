using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // 追従するターゲット（プレイヤー）
    public Vector3 offset = new Vector3(0, 5, -5); // カメラの固定オフセット
    public float smoothSpeed = 5.0f; // カメラの移動の滑らかさ

    private void LateUpdate()
    {
        if (target == null) return;

        // 位置の更新（ターゲットのオフセット位置に滑らかに移動）
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);

        // カメラの回転を滑らかに補間
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smoothSpeed);
    }
}
