using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    private GameObject source;
    private GameObject destination;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void HighlightDestination(){

    }

    public GameObject GetSource() => source;
    public GameObject GetDestination() => destination;

    public void SetDestination(GameObject dest) => destination = dest;
    public void SetSource(GameObject sour) => source = sour;
}
