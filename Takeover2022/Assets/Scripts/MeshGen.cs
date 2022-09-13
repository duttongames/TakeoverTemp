using System;
using System.Collections;
using UnityEngine;

namespace MeshGen
{
    [RequireComponent(typeof(MeshFilter))]
    public class MeshGen : MonoBehaviour
    {
        double NEG_X, NEG_Y = -1;
        double POS_X, POS_Y = 1;

        static void Start()
        {
            CREATE_SHAPE();
        }

        static void CREATE_SHAPE()
        {
            Vector3[] Vertices = new Vector3[]
            {
                new Vector3(0,0,0),
                new Vector3(0,0,1),
                new Vector3(1,0,0)
            };

            int[] TRI = new int[]
            {
                1,0,2,
                3,1,2
            };
        }
    }
}
