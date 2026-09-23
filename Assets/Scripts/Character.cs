using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Health health;
    protected Collider characterCollider;
    [SerializeField]
    protected Animator characterAniamtor;
    protected virtual void Awake()
    {
        health = GetComponent<Health>();
        characterCollider = GetComponent<Collider>();
    }
    public virtual void Die()
    {
        characterCollider.enabled = false;
        StartCoroutine(DieCoroutine());
    }
    private IEnumerator DieCoroutine()
    {
        characterAniamtor.Play("Die", 0, 0f);
        yield return characterAniamtor.WaitForCurrentAnimation();
        gameObject.SetActive(false);
    }
}
