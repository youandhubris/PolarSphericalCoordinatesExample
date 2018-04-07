using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Hubris;

public class CoordinatesExampleFun : MonoBehaviour
{
    const int num = 100;

    [Range(-1f, 1f)]
    public float qX, qY, qZ, qW;

    Transform capsParent;
    Transform spheParent;

    void Start ()
	{
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        capsParent = gameObject.GetComponentsInChildren<Transform>()[2];


        for (int i = 0; i < num; i++)
        {
            float normalize = (float)i / num;
            Polar pos = new Polar(10f + Arithmos.SinNormalized(normalize * Arithmos.TWO_PI * 12f) * 5f, normalize * Arithmos.TWO_PI, 0f, Polar.BasePlane.XY);

            normalize *= 2f;
            normalize -= Mathf.Floor(normalize);
            normalize *= 2f;

            Quaternion rot = new Quaternion(0f, 0f, normalize - 1f, 1f);

            Instantiate(obj, pos, rot, capsParent);
        }

        Destroy(obj);
        obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        spheParent = gameObject.GetComponentsInChildren<Transform>()[1];

        for (int i = 0; i < num; i++)
        {
            float normalize = (float)i / num;
            Spherical pos = new Spherical(25f, normalize * Arithmos.TWO_PI, (normalize - 0.5f) * Arithmos.PI);
            Quaternion rot = new Quaternion();
            Instantiate(obj, pos, rot, spheParent);
        }

        Destroy(obj);

    }
	
	void Update ()
	{
        capsParent.Rotate(0f, 0f, Mathf.Sin(Time.time));
        spheParent.Rotate(0f, Mathf.Sin(Time.time) * Arithmos.PI, 0f);
	}
}