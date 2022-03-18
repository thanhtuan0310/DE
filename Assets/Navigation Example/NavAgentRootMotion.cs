using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavAgentRootMotion : MonoBehaviour
{
    public static NavAgentRootMotion Instance { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
