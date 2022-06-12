using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float StartingHealth = 100.0f;
    
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
    }private float _HealthPoints = 100f;

    public void heal(float Amount) {
        HealthPoints += Amount;
    }

    public void damage(float Amount) {
        HealthPoints -= Amount;
    }

    // Start is called before the first frame update
    void Start()
    {
        HealthPoints = StartingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
