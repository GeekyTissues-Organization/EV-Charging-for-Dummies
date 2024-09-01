using UnityEngine;


public class ScenarioHandler : MonoBehaviour
{
    public CableController cableController;
    public bool StationPaid = false; 
    public bool PaymentSuccessful = false;
    public bool PaymentErrorOccurred = false;

    public GameObject PaymentButton;
    public Material GreenMaterial;

    public GameObject ChargingStation; 
    public Material RedMaterial; 

    public void OnPaymentButtonPressed()
    {
        if (cableController.IsCableConnected())
        {
            Debug.Log("Payment Successful. Charging started");
            PaymentSuccessful = true;
            StationPaid = true;
            PaymentErrorOccurred = false; 
            AcknowledgePayment();
        }
        else
        {
            Debug.Log("Cable not connected");
        }
    }

    private void AcknowledgePayment()
    {
        if (StationPaid && PaymentButton != null && GreenMaterial != null)
        {
            Debug.Log("Changing button to green");
            Renderer ButtonRenderer = PaymentButton.GetComponent<Renderer>();

            if (ButtonRenderer != null)
            {
                ButtonRenderer.material = GreenMaterial;
            }
            else
            {
                Debug.LogError("Renderer not found button");
            }
        }
    }

    public void SimulatePaymentError()
    {
        if (PaymentSuccessful)
        {
            Debug.Log("Payment Error");
            PaymentErrorOccurred = true; 
            UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable = cableController.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            if (grabInteractable != null)
            {
                grabInteractable.enabled = false;
                Debug.Log("Cable grab disabled");
            }
            else
            {
                Debug.LogError("XRGrabInteractable not found");
            }
            SignalPaymentError();
        }
    }

    private void SignalPaymentError()
    {
        if (PaymentErrorOccurred && ChargingStation != null && RedMaterial != null)
        {
            Debug.Log("Changing station to red");
            Renderer stationRenderer = ChargingStation.GetComponent<Renderer>();

            if (stationRenderer != null)
            {
                stationRenderer.material = RedMaterial;
            }
            else
            {
                Debug.LogError("Renderer not found on the charging station!");
            }
        }
    }

    public void HandleNextScenarioPlaceholder()
    {
        Debug.Log("This is a placeholder for where the next scenario goes");
    }
}
