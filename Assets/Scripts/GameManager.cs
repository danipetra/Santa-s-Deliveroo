using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Range(30, 120)]private int _gameTime;
    [SerializeField, Range(15, 100)]private int _levelMaxScore;

    private float _timeLeft;
    private GameObject _player;
    
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
