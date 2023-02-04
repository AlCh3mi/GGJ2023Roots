using System;
using System.Collections;
using UnityEngine;

namespace StarterAssets
{
    public class Torch : MonoBehaviour
    {
        [SerializeField] private StarterAssetsInputs input;
        [SerializeField] private Animator anim;
        [SerializeField] private SphereCollider torchCollider;
        [SerializeField] private float damage;

        private void OnEnable()
        {
            input.attack += OnAttack;
        }

        private void OnDisable()
        {
            input.attack -= OnAttack;
        }

        private void OnAttack()
        {
            torchCollider.enabled = true;
            anim.SetTrigger("Attack");
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("TORCH COLLIDED WITH "+collision.gameObject.name);
            if (collision.gameObject.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(damage);
                Debug.Log("Damage dealt to IDamageable");
            }
        }
    }
}