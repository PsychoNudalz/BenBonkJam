using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mood : MonoBehaviour
{
    public float StartingMood = 50f;
    
    public float MoodPoint
    {
        get { return _Mood;}
        set {
            // Make Mood in the range 0f to 100f
            _Mood = Mathf.Clamp(value, 0f, 100f);
            if(MoodPoint <= 0f) 
            {
                //No mood
            }
        }
    }
    private float _Mood = 50f;

    // Start is called before the first frame update
    void Start()
    {
        MoodPoint = StartingMood;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
