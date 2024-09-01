using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonMovementScript : MonoBehaviour
{
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    public void OnPress()
    {
        transform.localPosition = originalPosition + new Vector3(0, -0.02f, 0);
        Debug.Log("Button Pressed");
    }

    public void OnRelease()
    {
        transform.localPosition = originalPosition;
        Debug.Log("Button Released");
    }
}
