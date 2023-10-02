using UnityEngine;
using System.Collections;

public class WebcamTextureScript : MonoBehaviour
{
    public Renderer renderer;

    void Start()
    {
        WebCamTexture webcamTexture = new WebCamTexture("USB CAMERA");
        foreach (WebCamDevice wc in WebCamTexture.devices)
        {
            Debug.Log(wc.name);
        }
        renderer.material.mainTexture = webcamTexture;
        webcamTexture.Play();
    }
}
