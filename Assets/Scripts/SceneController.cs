using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.Collections;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onSceneStart;
    [SerializeField]
    private Animator fade;
    [SerializeField]
    private string fadeAnimatonName = "FadeOut";
    private void Start()
    {
        onSceneStart?.Invoke();
    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }
    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        fade.Play(fadeAnimatonName);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
