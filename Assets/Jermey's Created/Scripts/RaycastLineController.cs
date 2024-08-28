using UnityEngine;


public class RayInteractorLineController : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor rayInteractor;
    public LineRenderer lineRenderer;

    void Update()
    {
        // Cast the ray
        if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            // Set the start and end positions of the line
            lineRenderer.SetPosition(0, rayInteractor.transform.position); // Controller position
            lineRenderer.SetPosition(1, hit.point); // Point where the ray hits
        }
        else
        {
            // If nothing is hit, extend the ray to its max length
            lineRenderer.SetPosition(0, rayInteractor.transform.position);
            lineRenderer.SetPosition(1, rayInteractor.transform.position + rayInteractor.transform.forward * rayInteractor.maxRaycastDistance);
        }
    }
}
