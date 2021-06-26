using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bux : MonoBehaviour
{
    public float StartingBux = 0f;
    
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

    // Start is called before the first frame update
    void Start()
    {
        BuxPoint = StartingBux;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
