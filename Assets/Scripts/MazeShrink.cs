using DG.Tweening;
using UnityEngine;

public class MazeShrink : MonoBehaviour
{
    [SerializeField] private Transform[] thingsToShrink;
    [SerializeField] private float shrinkTime;
    
    [ContextMenu("Shrink")]
    public void Shrink()
    {
        var parent = transform;
        foreach (var tf in thingsToShrink)
        {
            tf.SetParent(parent);
        }
        transform.DOScale(new Vector3(1,0,1), shrinkTime).OnComplete(() =>
        {
            parent.gameObject.SetActive(false);
        });
    }
}