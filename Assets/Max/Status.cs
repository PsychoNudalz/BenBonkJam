using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    enum DamageType {HEALTH, BUX, MOOD};

    Health health;
    Bux bux;
    Mood mood;

    public void TakeDamage(float amount) {
        health.damage(50f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
