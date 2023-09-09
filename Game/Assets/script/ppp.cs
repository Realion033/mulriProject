using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ppp : MonoBehaviour
{
    public GameObject aa;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            aa.SetActive(false);
        }
    }
}
