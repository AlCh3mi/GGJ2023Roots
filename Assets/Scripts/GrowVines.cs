using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowVines : MonoBehaviour, IDamageable
{
    [SerializeField] private bool startGrown;
    [SerializeField] private Collider meshCollider;
    [SerializeField] private float growTime = 2f;
        
    private MeshRenderer[] renderers;
    private List<Material> mats = new ();
    public AudioSource audioSource;

    private void Awake()
    {

        if (!audioSource)
            audioSource = GetComponent<AudioSource>();
            
        renderers = GetComponentsInChildren<MeshRenderer>();
        foreach (var renderer in renderers)
        {
            mats.Add(renderer.material);
            renderer.material.SetFloat("_Grow", startGrown ? 1 : 0);
        }
    }

    [ContextMenu("Grow")]
    public void GrowTest() => Grow(true);

    [ContextMenu("Shrink")]
    public void ShrinkTest() => Grow(false);
        
    public void Grow(bool grow)
    {
        meshCollider.enabled = grow;
        StartCoroutine(GrowRoutine(grow, growTime));
        audioSource.Play();
    }

    private IEnumerator GrowRoutine(bool grow, float lerpTime)
    {
        var elapsed = 0f;
            
        while(elapsed < lerpTime)
        {
            elapsed += Time.deltaTime;
            foreach (var mat in mats)
                mat.SetFloat("_Grow", Mathf.Lerp(grow ? 0f: 1f, grow ? 1f : 0f, elapsed / lerpTime));

            yield return null;
        }
    }

    public void TakeDamage(float dmg)
    {
        Grow(false);
    }
}