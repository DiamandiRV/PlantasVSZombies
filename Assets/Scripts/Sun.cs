using UnityEngine;
using System.Collections;

public class Sun : MonoBehaviour
{
    [SerializeField]
    private int value;
    public int Value => value;
    [SerializeField]
    private GameObject sunParticles;
    [SerializeField]
    private string colectSound;
    [SerializeField]
    private float duration;
    private Collider assetCollieder;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        assetCollieder = GetComponent<Collider>();
    }
    private void OnEnable()
    {
        assetCollieder.enabled = true;
        animator.Play("Appear", 0, 0f);
        StartCoroutine(AutoDeactivate());
    }
    public void Collect()
    {
        StopAllCoroutines();
        assetCollieder.enabled = false;
        SoundManager.instance.Play(colectSound);
        PoolManager.Instance.GetObject(sunParticles, transform.position);
        gameObject.SetActive(false);
    }
    private IEnumerator AutoDeactivate()
    {
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }
}
