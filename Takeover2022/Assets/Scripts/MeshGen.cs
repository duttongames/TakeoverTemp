using System;
using System.Collections;
using UnityEngine;

namespace MeshGen
{
    [RequireComponent(typeof(MeshFilter))]
    public class MeshGen : MonoBehaviour
    {
        // DOUBLE VALUE NOTATION TO REPRESENT POINTS //
        private double NEG_X, NEG_Y = -1;
        private double POS_X, POS_Y = 1;

        static void Start()
        {
            CREATE_SHAPE();
        }

        // THE MAIN FUNCTION FOR MESH GENERATION //
        static void CREATE_SHAPE()
        {
            // USING VECTOR3 NOTATION TO DESCERN ALL 3 AXES //
            // THEIR POINTS ARE SCAILABLE AND CAN BE ADJUSTED RELATIVELY // 
            Vector3[] Vertices = new Vector3[]
            {
                new Vector3(0,0,0),
                new Vector3(0,0,1),
                new Vector3(1,0,0)
            };

            // INT ARRAY TO INITIALISE TRIANGULATION //
            int[] TRI = new int[]
            {
                1,0,2,
                3,1,2
            };
        }
    }
}
