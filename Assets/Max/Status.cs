using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Status : MonoBehaviour
{
    public List<StatusEnum> currentstatus;


   public void AddStatus(StatusEnum status) {
       if(!currentstatus.Contains(status)) {
        currentstatus.Add(status);
       }
   }

   public void RemoveStatus(StatusEnum status) {
       if(currentstatus.Contains(status)) {
           currentstatus.Remove(status);
       }
   }

    public bool HasSatus(StatusEnum statusEnum)
    {
        return currentstatus.Contains(statusEnum);
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
