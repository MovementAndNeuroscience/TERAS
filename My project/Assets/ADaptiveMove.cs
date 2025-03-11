using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADaptiveMove : MonoBehaviour
{
    public GameObject pcCam;
    public GameObject objectOfInterest;
    private float heightOfObject;
    private float verticalFOVpcCam; 
    private float verticalFOVvrCam;
    private float tanPcFOV;   
    private float tanVrFOV;
    private float halfheight;
    private float startposZ; 
    // Start is called before the first frame update
    void Start()
    {
        startposZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        heightOfObject = objectOfInterest.transform.lossyScale.y;
        verticalFOVvrCam = GetComponent<Camera>().fieldOfView;
        
        verticalFOVpcCam = pcCam.GetComponent<Camera>().fieldOfView;
        halfheight = heightOfObject / 2;
        tanPcFOV = Mathf.Tan(Mathf.Deg2Rad * (verticalFOVpcCam / 2)); 
        tanVrFOV = Mathf.Tan(Mathf.Deg2Rad * (verticalFOVvrCam / 2));
        var difDistance = (halfheight / tanPcFOV) - (halfheight / tanVrFOV);
        transform.position = new Vector3(transform.position.x, transform.position.y, startposZ - difDistance);
    }
}
