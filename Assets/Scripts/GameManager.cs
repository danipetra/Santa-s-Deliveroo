using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Range(30, 120)]private int gameTime;
    [SerializeField, Range(15, 100)]private int levelMaxScore;

    private float timeLeft;
    private GameObject player;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private bool TheresTimeLeft(){
        return true;
    }
}
