using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnMesh : MonoBehaviour
{
    Mesh mesh;
    Vector3[] verticals; // assign verticals arrays
    public int verticalsNumbers;

    
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        verticals = mesh.vertices;
        verticalsNumbers = mesh.vertexCount;
        Debug.Log(verticalsNumbers);
    }

    void Update()
    {
        for(int i = 0; i < verticals.Length; i++)
        {
            verticals[i] += Vector3.up * Time.deltaTime;
        }

        mesh.vertices = verticals;
        mesh.RecalculateBounds();
    }
}
