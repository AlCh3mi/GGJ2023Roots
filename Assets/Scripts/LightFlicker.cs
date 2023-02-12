using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class LightFlicker : MonoBehaviour
{
    [SerializeField] private float min, max;
    [SerializeField] private float frequency = 0.3f;
    [SerializeField] private Light targetLight;

    [SerializeField] private bool _active;
    public bool Active 
    {
        get => _active;
        private set
        {
            _active = value;
            if(!_active)
            {
                StopCoroutine(flickerRoutine);
                flickerRoutine = null;
                return;
            }
            flickerRoutine ??= StartCoroutine(FlickerRoutine());
        }
    }

    private void Start()
    {
        SetActive(_active);
    }

    private Coroutine flickerRoutine;

    public void SetActive(bool active)
    {
        Active = active;
    }

    private IEnumerator FlickerRoutine()
    {
        var interval = new WaitForSeconds(frequency);
        while (Active)
        {
            Flicker();
            yield return interval;
        }
    }
    
    private void Flicker()
    {
        var random = Random.Range(min, max);
        targetLight.intensity = random;
        targetLight.range = random;
    }

    #region Debug

    [ContextMenu("Activate Flicker")]
    public void ActivateFlicker() => SetActive(true);

    [ContextMenu("Deactivate Flicker")]
    public void DeactivateFlicker() => SetActive(false);

    #endregion
}