﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterAssets
{
    public class GrowVines : MonoBehaviour
    {
        [SerializeField] private bool startGrown;
        [SerializeField] private Collider meshCollider;
        [SerializeField] private float growTime = 2f;
        
        private MeshRenderer[] renderers;
        private List<Material> mats = new ();

        private void Awake()
        {
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
            meshCollider.gameObject.SetActive(grow);
            StartCoroutine(GrowRoutine(grow, growTime));
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
    }
}