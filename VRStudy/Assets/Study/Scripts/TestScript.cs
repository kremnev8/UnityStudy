using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public float randomNumber = 7;
    public GameObject myObject;

    // Start is called before the first frame update
    void Start()
    {
        Randomize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Randomize()
    {
        randomNumber = Random.Range(1, 100);
        Debug.Log(randomNumber);
    }
    
}
