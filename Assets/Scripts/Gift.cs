using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    private GameObject _source;
    private GameObject _destination;

    [SerializeField, Range(1, 10)]private float _weight; // each gift makes santa more slow
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void HighlightDestination()
    {

    }

    public GameObject GetSource() => _source;
    public GameObject GetDestination() => _destination;

    public void SetDestination(GameObject dest) => _destination = dest;
    public void SetSource(GameObject sour) => _source = sour;
}
