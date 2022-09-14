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

        // DOUBLE VALUE NOTATION YET AGAIN TO INIT POS AND NEG X AND Z // 
        // FOR ITERATION TO CREATE VERTICES AROUND THOSE AXES // 
        private double X_SIZE;
        private double Z_SIZE;

        static void Start()
        {
            CREATE_SHAPE();
            UPDATE_MESH();
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

            // ITERATION TO INITIALISE TRIANGULATION BETWEEN FACES

            TRI[] = new int[]
            {
                for (int T = 0; T < 6)
            {
                TRI = 0;
                TRI = 1 + X_SIZE + 1;
                TRI = 2;
                TRI = 3;
                TRI = 4 + X_SIZE + 1;
                TRI = 5 + X_SIZE + 2;
            }
        }

            // ITERATION BETWEEN X AND Z TO CREATE VERTICES
            for(int z = 0; z <= Z_SIZE; Z++)
            {
                while(int x = 0; x <= X_SIZE; X++)
                {
                    Vertices[i] = new Vector3(X, 0, Z);
        i++;
                }
}

// A SELF-EXPLANATORY FUNCTION... ¯\_(ツ)_/¯ //
static void UPDATE_MESH()
{
    MESH.clear();
    MESH.Vertices = Vertices;
    MESH.TRI = TRI;
    Mesh.RecalculateNormals();
}

private partial void OnDrawGizmos()
{
    while (!Vertices)
        return;

    // ITERATION BETWEEN THE LENGTH OF THE VERTICES TO DRAW A DESIGNATED SHAPE //
    for (int i  0; i < Vertices.length; i++)
                {
        Gizmos.DrawSphere(Vertices[i], .1f);
    }
}
        }
    }
}
