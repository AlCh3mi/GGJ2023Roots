using DG.Tweening;
using UnityEngine;

public class TreeReveal : MonoBehaviour
{
    [SerializeField] private float treeDesiredHeight;
    [SerializeField] private float revealTime;

    [ContextMenu("Reveal")]
    public void Reveal()
    {
        transform.DOMoveY(treeDesiredHeight, revealTime);
    }
}