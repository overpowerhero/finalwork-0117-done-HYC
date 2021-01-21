using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateAnimal : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Ganimal", 1.0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.Return))
        //{

           // Ganimal();
        //}
    }

    void Ganimal() 
    {

        int animal_indexer = Random.Range(0, animalPrefabs.Length);
        int x_pos = Random.Range(-20, 20);
       
        //需要多個Z軸
        Instantiate(animalPrefabs[animal_indexer], new Vector3(x_pos, 0, 0), animalPrefabs[animal_indexer].transform.rotation);
        



    }
}
