using UnityEngine;

public class DisableTorchOnHit : MonoBehaviour
{
    [SerializeField] private SphereCollider torchCollider;
        
    private void DisableColliderOnTorch()
    {
        torchCollider.enabled = false;
    }
}