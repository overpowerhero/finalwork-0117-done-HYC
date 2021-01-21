using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Animal : MonoBehaviour
{

    private float m_LastUpdateShowTime = 0f;    //上一次更新幀率的時間;

    private float m_UpdateShowDeltaTime = 0.01f;//更新幀率的時間間隔;

    private int m_FrameUpdate = 0;//幀數;

    private float m_FPS = 0;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }


    public float speed;//0114 張琇媗

    
    private Rigidbody enemyRb;//lok 0108
    private GameObject player;//lok 0108

    // Start is called before the first frame update
    void Start()
    {
        //lok 0108-HYC
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Human");



        m_LastUpdateShowTime = Time.realtimeSinceStartup;//更新FPS
    }

    // Update is called once per frame
    void Update()
    {
        //lok 0108
        Vector3 lookDirection = (player.transform.position- transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed );

        transform.LookAt(player.transform);//0114 張琇媗


        m_FrameUpdate++;
        if (Time.realtimeSinceStartup - m_LastUpdateShowTime >= m_UpdateShowDeltaTime)
        {
            m_FPS = m_FrameUpdate / (Time.realtimeSinceStartup - m_LastUpdateShowTime);
            m_FrameUpdate = 0;
            m_LastUpdateShowTime = Time.realtimeSinceStartup;
        }//更新FPS值
    }

    //0114 張琇媗
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("arms"))
        {
            Destroy(other.gameObject);
        }
    }


    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2, 0, 100, 100), "FPS: " + m_FPS);
    }//顯示FPS值
}
