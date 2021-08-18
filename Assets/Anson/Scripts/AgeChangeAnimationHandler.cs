using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeChangeAnimationHandler : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] List<AgeTilingPair> tilingPair;
    [Range(0f, 1f)]
    [SerializeField] float AgeEffectScale;

    [Header("Components")]
    [SerializeField] Animator animator;
    [SerializeField] Material material;
    public static AgeChangeAnimationHandler current;


    [System.Serializable]
    struct AgeTilingPair
    {
        public AgeEnum ageEnum;
        public Vector2 tiling;
    }

    private void Awake()
    {
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }
        if (!material)
        {
            material = GetComponent<SpriteRenderer>().material;
        }
        current = this;
    }

    private void Update()
    {
        material.SetFloat("_Scale", AgeEffectScale);
    }

    public void PlayAnimation(AgeEnum ageEnum)
    {
        material.SetVector("_TileSize", GetTiling(ageEnum));

        animator.Play($"AgeChange_{ageEnum.ToString()}");
    }

    Vector2 GetTiling(AgeEnum ageEnum)
    {
        foreach(AgeTilingPair atp in tilingPair)
        {
            if (atp.ageEnum.Equals(ageEnum))
            {
                return atp.tiling;
            }
        }
        return tilingPair[0].tiling;
    }

}
