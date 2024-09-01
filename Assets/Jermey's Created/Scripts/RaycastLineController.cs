using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RayInteractorLineController : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor rayInteractor;
    public LineRenderer lineRenderer;

    void Update()
    {
        if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            lineRenderer.SetPosition(0, rayInteractor.transform.position); 
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            lineRenderer.SetPosition(0, rayInteractor.transform.position);
            lineRenderer.SetPosition(1, rayInteractor.transform.position + rayInteractor.transform.forward * rayInteractor.maxRaycastDistance);
        }
    }
}
