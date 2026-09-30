using UnityEngine;
using UnityEngine.InputSystem;

public class GazeButton : MonoBehaviour
{
    private Renderer buttonRenderer;
    private int count = 0;

    void Start()
    {
        buttonRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(
            new Vector3(0.5f, 0.5f, 0)
        );

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform == transform)
            {
                buttonRenderer.material.color = Color.green;

                if (Mouse.current != null &&
                    Mouse.current.leftButton.wasPressedThisFrame)
                {
                    count++;
                    Debug.Log($"Button pressed {count} times");
                }

                return;
            }
        }

        buttonRenderer.material.color = Color.white;
    }
}
