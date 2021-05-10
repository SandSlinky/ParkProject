using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text text;
    public int score;
    [SerializeField] private BikingMovement2 bikingMovement2;
    [SerializeField] private CameraMovement cameraMovement;
    
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScore(int pointValue)
    {
        score += pointValue;
        text.text = "X"+score.ToString();
    }
}
