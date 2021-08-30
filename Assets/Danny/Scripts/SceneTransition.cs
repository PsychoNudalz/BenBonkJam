using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition Instance;
    private Animator animator;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            animator = GetComponent<Animator>();
        }
    }

    public void FadeToScene(int sceneIndex)
    {
        Instance.StartCoroutine(FadeToSceneCoroutine(sceneIndex));
    }

    IEnumerator FadeToSceneCoroutine(int SceneIndex)
    {
        
        animator.SetTrigger("FadeOut");
        FindObjectOfType<MusicFader>().StartFade("Master",2,0);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneIndex);
        animator.SetTrigger("FadeIn");
        FindObjectOfType<MusicFader>().StartFade("Master",2,1);
    }

}
