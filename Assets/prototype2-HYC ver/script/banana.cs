using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banana : MonoBehaviour
{

    public float speed = 30;
    // Start is called before the first frame update
    void Start()
    {
         
    } 

    // Update is called once per frame
    void Update()
    {


        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    //0114 張琇媗
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("chicken"))
        {
            Destroy(other.gameObject);
        }
    }
}
