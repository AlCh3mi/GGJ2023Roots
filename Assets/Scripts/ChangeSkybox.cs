using UnityEngine;

public class ChangeSkybox : MonoBehaviour
{
    [SerializeField] private Material newSkybox;

    public void ChangeSky()
    {
        RenderSettings.skybox = newSkybox;
    }
}