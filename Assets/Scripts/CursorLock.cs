using UnityEngine;

public class CursorLock : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.Escape;
    public GameObject player;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        /*if (Input.GetKeyDown(toggleKey))
        {
            Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;
        }

        if (Cursor.lockState != CursorLockMode.Locked) return;
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        player.transform.Rotate(Vector3.up * mouseX);
        player.transform.Rotate(Vector3.right * -mouseY);*/
    }
}