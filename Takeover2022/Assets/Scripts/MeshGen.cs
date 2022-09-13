using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGen
{
    public class MeshGen : MonoBehaviour
    {
        static void Awake()
        {
            Mesh MESH = new Mesh();
            MESH.name = "Proc";

            int[] TRI = new int[]
            {
                1,0,2,
                3,1,2
            };

            MESH.triangles = TRI;
            return;
        }

        static void SET_VERTS()
        {
            double NEG_X, NEG_Y = -1;
            double POS_X, POS_Y = 1;
        }
    }
}
