using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CableController : MonoBehaviour
{
    public bool isConnectedToCar = false;
    public bool isConnectedToStation = false;

    public GameObject carSocket;
    public GameObject StationSocket;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == carSocket)
        {
            isConnectedToCar = true;
            Debug.Log("Cable connected to car");
        }
        else if (other.gameObject == StationSocket)
        {
            isConnectedToStation = true;
            Debug.Log("Cable connected to charging station");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == carSocket)
        {
            isConnectedToCar = false;
            Debug.Log("Cable disconnected from car");
        }
        else if (other.gameObject == StationSocket)
        {
            isConnectedToStation = false;
            Debug.Log("Cable disconnected from charging station");
        }
    }

    public bool IsCableConnected()
    {
        return isConnectedToCar && isConnectedToStation;
    }
}
