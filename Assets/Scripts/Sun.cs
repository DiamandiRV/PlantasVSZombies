using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField]
    private int value;
    public int Value => value;
    [SerializeField]
    private GameObject sunParticles;
    [SerializeField]
    private string colectSound;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        animator.Play("Appear", 0, 0f);
    }
    public void Collect()
    {
        SoundManager.instance.Play(colectSound);
        PoolManager.Instance.GetObject(sunParticles, transform.position);
        gameObject.SetActive(false);
    }
}
