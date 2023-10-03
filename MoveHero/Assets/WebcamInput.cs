using UnityEngine;
using System.Collections.Generic;
using Mediapipe.Unity.HandTracking;

public class WebcamInput : MonoBehaviour
{
    public HandTrackingSolution handTrackingSolution;
    public GameObject leftHandSprite;
    public GameObject rightHandSprite;
    /*
    void Update()
    {
        List<NormalizedLandmarkList> handLandmarks;
        List<ClassificationList> handedness;

        // Supondo que o HandTrackingSolution esteja em modo síncrono
        var result = handTrackingSolution.TryGetNext(out _, out _, out handLandmarks, out _, out _, out handedness, true);

        if (result && handLandmarks != null && handedness != null)
        {
            for (int i = 0; i < handLandmarks.Count; i++)
            {
                var handLandmark = handLandmarks[i];
                var handClassification = handedness[i];
                var isLeftHand = handClassification[0].Index == 0;

                // Convertendo coordenadas normalizadas para coordenadas de tela
                // Você pode precisar ajustar esta transformação para corresponder ao seu setup
                var handPosition = new Vector3(handLandmark[0].X * Screen.width, handLandmark[0].Y * Screen.height, 0);

                if (isLeftHand)
                {
                    leftHandSprite.transform.position = Camera.main.ScreenToWorldPoint(handPosition);
                }
                else
                {
                    rightHandSprite.transform.position = Camera.main.ScreenToWorldPoint(handPosition);
                }
            }
        }
    }
    */
}
