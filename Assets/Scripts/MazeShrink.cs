using DG.Tweening;
using UnityEngine;

public class MazeShrink : MonoBehaviour
{
    [SerializeField] private Transform[] thingsToShrink;
    [SerializeField] private float shrinkTime;
    
    [ContextMenu("Shrink")]
    public void Shrink()
    {
        foreach (var tf in thingsToShrink)
        {
            var colliders = tf.GetComponentsInChildren<Collider>();
            foreach (var col in colliders)
            {
                col.enabled = false;
            }

            tf.DOScale(new Vector3(1, 0, 1), shrinkTime).OnComplete(() => tf.gameObject.SetActive(false));
        }
    }
}