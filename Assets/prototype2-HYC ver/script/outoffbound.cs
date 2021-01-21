using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outoffbound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //for food&animal
        //shiouuu 1/9
        if (transform.position.x > 26 )
        {
            Destroy(gameObject);
        }
        if (transform.position.x<-26)
        {
            Destroy(gameObject);
        }
        if (transform.position.z>35)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < -70)
        {
            Destroy(gameObject);
        }





    }


}
