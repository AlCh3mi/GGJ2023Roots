using UnityEngine;

namespace StarterAssets
{
    public class DisableTorchOnHit : MonoBehaviour
    {
        [SerializeField] private SphereCollider torchCollider;
        
        private void DisableColliderOnTorch()
        {
            torchCollider.enabled = false;
        }
    }
}