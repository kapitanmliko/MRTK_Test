using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;

public class DesktopAndVRSwitcher : MonoBehaviour
{

    //private new Camera camera;

    #region Unity Callbacks

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("Start XR");
            StopVR();
            StartCoroutine(StartXR());
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("Initialze Desktop");
            StopVR();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("XR Settings: " + XRSettings.stereoRenderingMode);
        }
    }
    #endregion

    #region Common Methods 
    /// <summary>
    /// Start VR Mode
    /// </summary>
    public void StartVRMode()
    {
        Debug.Log("Start XR");
        StartCoroutine(StartXR());
    }

    /// <summary>
    /// Start VR Mode Coroutine
    /// </summary>
    private IEnumerator StartXR()
    {
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();
        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.LogError("Initializing XR Failed. Check Editor or Player log for details.");
        }
        else
        {
            Debug.Log("Starting XR...");
            XRGeneralSettings.Instance.Manager.StartSubsystems();
        }
    }

    /// <summary>
    /// Stop VR Mode
    /// </summary>
    public void StopVR()
    {
            XRGeneralSettings.Instance.Manager.StopSubsystems();
            XRGeneralSettings.Instance.Manager.DeinitializeLoader();
    }
    #endregion

}
