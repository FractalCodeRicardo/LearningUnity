using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mandel : MonoBehaviour
{

    private float pi = 3.14159265f;
    private int maxIterations = 20;
    private int maxX = 1;
    private int maxY = 1;
    private int maxZ = 1;
    private float step = 0.05f;
    private float maxDistance = 0;


    void Start()
    {
        maxDistance = (float)System.Math.Sqrt(maxX * maxX + maxY * maxY + maxZ * maxZ);

        for (float x = maxX * -1; x <= maxX; x = x + step)
        {
            for (float y = maxY * -1; y <= maxY; y = y + step)
            {
                for (float z = maxZ * -1; z <= maxZ; z = z + step)
                {

                    Vector3 c = new Vector3(x, y, z);
                    int i = GetDivergingIteration(c);

                    if (i >= maxIterations)
                    {
                        Debug.Log("x: " + x + "y: " + "z: " + z);
                        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        cube.transform.localPosition = new Vector3(x, y, z);
                        cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    };
                }
            }
        }


    }

    void Update()
    {
        //Rotate the cube
        //_cube.transform.Rotate(5f * Time.deltaTime, 15f * Time.deltaTime, 3f * Time.deltaTime);
    }


    private int GetDivergingIteration(Vector3 c)
    {
        int i = 0;

        Vector3 zn = new Vector3();

        while (i < maxIterations)
        {

            float distance = zn.magnitude;

            if (distance > maxDistance) //is divergent
                break;


            //zn ^ n

            zn = pow(zn, 8);

            //zn ^ n + c

            zn = zn + c;

            i++;
        }

        return i;
    }

    private Vector3 pow(Vector3 p, int n)
    {
        float x = p.x;
        float y = p.y;
        float z = p.z;


        double r = Math.Sqrt(x * x + y * y + z * z);
        double theta = Math.Atan2(Math.Sqrt(x * x + y * y), z);
        double phi = Math.Atan2(y, x);

        float tx = (float)(Math.Pow(r, n) * Math.Sin(theta * n) * Math.Cos(phi * n));
        float ty = (float)(Math.Pow(r, n) * Math.Sin(theta * n) * Math.Sin(phi * n));
        float tz = (float)(Math.Pow(r, n) * Math.Cos(theta * n));

        return new Vector3(tx, ty, tz);
    }




}
