using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PhotoManager : MonoBehaviour
{
    public MeshRenderer _LeftSphereMeshRenderer;
    public MeshRenderer _RightSphereMeshRenderer;

    [System.Serializable]
    public class PhotoSphereDataObject
    {
        public Material _LeftSphereTexture;
        public Material _RightSphereTexture;
    }

    public PhotoSphereDataObject[] _PhotoSpheres;
    private int cameraOptionsIndex;

    public void ChangeOptionsNext()
    {
        cameraOptionsIndex++;
        int optionIndex = cameraOptionsIndex % _PhotoSpheres.Length;
        _LeftSphereMeshRenderer.material = _PhotoSpheres[optionIndex]._LeftSphereTexture;
        _RightSphereMeshRenderer.material = _PhotoSpheres[optionIndex]._RightSphereTexture;
    }

    public void ChangeOptionsBack()
    {
        cameraOptionsIndex--;
        if(cameraOptionsIndex < 0)
        {
            cameraOptionsIndex = _PhotoSpheres.Length;
        }
        int optionIndex = cameraOptionsIndex % _PhotoSpheres.Length;
        _LeftSphereMeshRenderer.material = _PhotoSpheres[optionIndex]._LeftSphereTexture;
        _RightSphereMeshRenderer.material = _PhotoSpheres[optionIndex]._RightSphereTexture;
    }

    void Update()
        //for mouseclick: (Input.GetMouseButtonDown(0)
    {    //for phone: Input.GetTouch(0).phase == TouchPhase.Began
         //set now for: Oculus Input

        if (OVRInput.Get(OVRInput.RawButton.DpadLeft))
        {
            ChangeOptionsNext();
        }
        if(OVRInput.Get(OVRInput.RawButton.DpadRight))
        {
            ChangeOptionsBack();
        }
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            ChangeOptionsNext();
        }
    }
}
