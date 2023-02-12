using UnityEngine;
using UnityEngine.Events;

public class MonoBehaviourCallbacks : MonoBehaviour
{
    [SerializeField] private UnityEvent awake;
    [SerializeField] private UnityEvent onEnable;
    [SerializeField] private UnityEvent start;
    [SerializeField] private UnityEvent onDisable;
    [SerializeField] private UnityEvent onDestroy;

    private void Awake() => awake?.Invoke();

    private void OnEnable() => onEnable?.Invoke();

    private void Start() => start?.Invoke();

    private void OnDisable() => onDisable?.Invoke();

    private void OnDestroy() => onDestroy?.Invoke();
}