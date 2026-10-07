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
        StopAllCoroutines();
        characterCollider.enabled = false;
        StartCoroutine(DieCoroutine());
    }
    private IEnumerator DieCoroutine()
    {
        characterAniamtor.Play("Death", 0, 0f);
        yield return characterAniamtor.WaitForCurrentAnimation();
        //yield return StartCoroutine(blinkCharacterCoroutine());
        gameObject.SetActive(false);
    }
    private IEnumerator blinkCharacterCoroutine()
    {
        float blinkDuration = 0.1f;
        int blinkCount = 5;
        for (int i = 0; i < blinkCount; i++)
        {
            characterAniamtor.gameObject.SetActive(!characterAniamtor.gameObject.activeSelf);
            yield return new WaitForSeconds(blinkDuration);
        }
        characterAniamtor.gameObject.SetActive(true);
    }
}
