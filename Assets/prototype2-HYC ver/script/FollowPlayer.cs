using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // public GameObject Human;
    //private Vector3 offset = new Vector3(0, 19, -15);


    public Transform target;

    public float distanceUp = 15f;
    public float distanceAway = 10f;
    public float smooth = 2f;//位置平滑移動值
    public float camDepthSmooth = 5f;
    // Use this for initialization
    //第三人稱(在玩家身後)

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Human.transform.position + offset; 

        // 鼠標軸控制相機的遠近
        if ((Input.mouseScrollDelta.y < 0 && Camera.main.fieldOfView >= 3) || Input.mouseScrollDelta.y > 0 && Camera.main.fieldOfView <= 80)
        {
            Camera.main.fieldOfView += Input.mouseScrollDelta.y * camDepthSmooth * Time.deltaTime;
        }

    }

    void LateUpdate()
    {
        //相機的位置
        Vector3 disPos = target.position + Vector3.up * distanceUp - target.forward * distanceAway;
        transform.position = Vector3.Lerp(transform.position, disPos, Time.deltaTime * smooth);
        //相機的角度
        transform.LookAt(target.position);
    }
}
