using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
   public List<cardStatus> currentstatus;


   public void AddStatus(cardStatus status) {
       if(!currentstatus.Contains(status)) {
        currentstatus.Add(status);
       }
   }

   public void RemoveStatus(cardStatus status) {
       if(currentstatus.Contains(status)) {
           currentstatus.Remove(status);
       }
   }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     /*enum DamageType {HEALTH, BUX, MOOD};

    Health health;
    Bux bux;
    Mood mood;

    public void TakeDamage(float amount) {
        health.damage(50f);
    }*/
}
