using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public Status status;
    public float StartingHealth = 100.0f;
    public float StartingBux = 0f;

    public float StartingMood = 50f;
    
    //Init age
    public AgeEnum age;
    public void Older() {
        int temp = (int)age;
        temp ++;
        age = (AgeEnum)temp;
        if((int)age > 5) {
               age = (AgeEnum)5; 
        }else{
            age = (AgeEnum)temp;
        }
    }

    public void Younger() {
        int temp = (int)age;
        temp --;
        if((int)age < 0) {
               age = (AgeEnum)0; 
        }else{
            age = (AgeEnum)temp;
        }
    }

    public void SetAge(int num) {
        int temp = num;
        age = (AgeEnum)temp;
    }

    //Init health
    private float _HealthPoints = 100f;
    public float HealthPoints
    {
        get { return _HealthPoints;}
        set {
            // Make the HP in the range 0f to 100f
            _HealthPoints = Mathf.Clamp(value, 0f, 100f);
            if(HealthPoints <= 0f) 
            {
                //dead
            }
        }
    }

    public void heal(float Amount) {
        HealthPoints += Amount;
    }

    public void damage(float Amount) {
        HealthPoints -= Amount;
    }

    //Init Bux
    public float BuxPoint
    {
        get { return _Bux;}
        set {
            // Make the cash in the range 0f to 1000f
            _Bux = Mathf.Clamp(value, 0f, 1000f);
            if(BuxPoint <= 0f) 
            {
                //No more money!
            }
        }
    }
    private float _Bux = 1000f;

    public void GainBux(float Amount) {
        BuxPoint += Amount;
    }

    public void LoseBux(float Amount) {
        BuxPoint -= Amount;
    }
    
    //Init Mood
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
    private float _Mood = 100f;

    public void GainMood(float Amount) {
        MoodPoint += Amount;
    }

    public void LoseMood(float Amount) {
        MoodPoint -= Amount;
    }

    // Start is called before the first frame update
    void Start()
    {
        HealthPoints = StartingHealth;
        BuxPoint = StartingBux;
        MoodPoint = StartingMood;
        SetAge(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
