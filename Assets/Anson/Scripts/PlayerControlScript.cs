using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControlScript : MonoBehaviour
{
    [Header("Line Renderer")]
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] float lineWidth = 0.1f;
    [SerializeField] float lineLength = 5f;
    [SerializeField] Vector3 lineDir = new Vector3(0, 1f);
    [SerializeField] AnimationCurve lineCurve;

    [Header("Control Stats")]
    [Range(0f, 1f)]
    [SerializeField] float launchForce ;
    [SerializeField] float forceRate = 2f;
    [SerializeField] bool isGain;
    [SerializeField] bool isCharging;
    [SerializeField] bool controlLock = false;
    [SerializeField] int Segments = 5;
    [Header("Fliper")]
    [SerializeField] CoinFlipScript coinFlipScript;
     // Start is called before the first frame update
    void Start()
    {
        if (!lineRenderer)
        {
            lineRenderer = GetComponentInChildren<LineRenderer>();
        }
        lineRenderer.widthMultiplier = lineWidth;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCharging)
        {
            ChargeForce();
        }
        ShowLaunchForce();
    }

    void ShowLaunchForce()
    {
        lineRenderer.SetPosition(0, new Vector3());
        lineRenderer.SetPosition(1, lineDir* lineLength * ConvertForce());
    }
    void ChargeForce()
    {
        if (isGain)
        {
        launchForce += forceRate * Time.deltaTime;

        }
        else
        {
            launchForce -= forceRate * Time.deltaTime;
        }
        if (launchForce <= 0f)
        {
            isGain = true;
        }
        else if (launchForce >= 1f)
        {
            isGain = false;
        }
        launchForce = Mathf.Clamp(launchForce, 0f, 1f);
    }

    public void SetCharge(InputAction.CallbackContext callbackContext)
    {
        if (controlLock)
        {
            return;
        }
        if (callbackContext.performed)
        {
            isCharging = true;
        }
        else if ( callbackContext.canceled)
        {
            if (isCharging)
            {
                coinFlipScript.LaunchCoin(ConvertForce());
                launchForce = 0f;
                SetControlLock(true);
            }
            isCharging = false;
        }
    }

    public void SetCharge(bool b)
    {
        if (controlLock)
        {
            return;
        }
        if (b)
        {
            isCharging = true;
        }
        else 
        {
            if (isCharging)
            {
                coinFlipScript.LaunchCoin(ConvertForce());
                launchForce = 0f;
                SetControlLock(true);
            }
            isCharging = false;
        }
    }

    public void SetControlLock(bool b)
    {
        controlLock = b;
    }

    public float ConvertForce()
    {
        float temp = lineCurve.Evaluate(launchForce);
        float i = 1f /(float) Segments;

        temp = temp - temp%i;
        return temp;
    }
}
