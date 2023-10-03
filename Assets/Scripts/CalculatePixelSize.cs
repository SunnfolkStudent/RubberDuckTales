using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatePixelSize : MonoBehaviour
{
    public Transform target;
    public Texture2D texture;
       
    private float distance;
    private float diameter;
    private float angularSize;
    private float pixelSize;
    private Vector3 scrPos;
       
    void Start () {
        diameter = target.GetComponent<Collider>().bounds.extents.magnitude;
    }
       
    void Update () {
        distance = Vector3.Distance(target.position, Camera.main.transform.position);
        angularSize = (diameter / distance) * Mathf.Rad2Deg;
        pixelSize = ((angularSize * Screen.height) / Camera.main.fieldOfView);
        scrPos = Camera.main.WorldToScreenPoint (target.position);
    }
       
    void OnGUI () {
        GUI.DrawTexture (new Rect(scrPos.x-pixelSize/2, Screen.height-scrPos.y-pixelSize/2, pixelSize, pixelSize), texture);
    }

    //Get the screen size of an object in pixels, given its distance and diameter.
    float DistanceAndDiameterToPixelSize(float distance, float diameter)
    {

        float pixelSize = (diameter * Mathf.Rad2Deg * Screen.height) / (distance * Camera.main.fieldOfView);
        return pixelSize;
    }

    //Get the distance of an object, given its screen size in pixels and diameter.
    float PixelSizeAndDiameterToDistance(float pixelSize, float diameter)
    {

        float distance = (diameter * Mathf.Rad2Deg * Screen.height) / (pixelSize * Camera.main.fieldOfView);
        return distance;
    }

    //Get the diameter of an object, given its screen size in pixels and distance.
    float PixelSizeAndDistanceToDiameter(float pixelSize, float distance)
    {

        float diameter = (pixelSize * distance * Camera.main.fieldOfView) / (Mathf.Rad2Deg * Screen.height);
        return diameter;
    }

}
