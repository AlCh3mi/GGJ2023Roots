using DG.Tweening;
using UnityEngine;

public class TreeReveal : MonoBehaviour
{
    [SerializeField] private float treeDesiredHeight;
    [SerializeField] private float revealTime;
    [SerializeField] private AudioSource source;

    [ContextMenu("Reveal")]
    public void Reveal()
    {
        if (source != null)
        {
            source.loop = false;
            source.Play();
        }
        
        transform.DOMoveY(treeDesiredHeight, revealTime);
    }
}