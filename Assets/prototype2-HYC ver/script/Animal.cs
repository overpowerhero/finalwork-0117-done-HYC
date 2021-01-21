using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Animal : MonoBehaviour
{

    public float speed;//0114 張琇媗

    
    private Rigidbody enemyRb;//lok 0108
    private GameObject player;//lok 0108

    // Start is called before the first frame update
    void Start()
    {
        //lok 0108-HYC
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Human");
    }
     
    // Update is called once per frame
    void Update()
    {
        //lok 0108
        Vector3 lookDirection = (player.transform.position- transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed );

        transform.LookAt(player.transform);//0114 張琇媗
    }

    //0114 張琇媗
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("arms"))
        {
            Destroy(other.gameObject);
        }
    }
}
