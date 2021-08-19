using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AgeChangeAnimationBackgroundHandler : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] float AgeEffectScale;
    [Header("Components")]
    [SerializeField] Animator animator;
    [SerializeField] Material material;

    public static AgeChangeAnimationBackgroundHandler current;

    private void Awake()
    {
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }
        if (!material)
        {
            material = GetComponent<Image>().material;
        }
        current = this;
    }

    private void Update()
    {
        material.SetFloat("_Scale", AgeEffectScale);
    }

    public void PlayEnd()
    {
        animator.SetTrigger("End");
    }

    public void PlayStart()
    {
        animator.SetTrigger("Start");
    }

}
