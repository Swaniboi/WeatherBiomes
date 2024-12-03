using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
	Mesh mesh;

	Vector3[] vertices;
	int[] triangles;
	Color[] colors;

	public int xSize = 20;
	public int zSize = 20;

	public float strength = 3f;

	public Gradient grad;

	float minHeight;
	float maxHeight;

	void Start()
	{
		mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;

		CreateShape();
		UpdateMesh();
	}

	void CreateShape()
	{
		vertices = new Vector3[(xSize + 1) * (zSize + 1)];
	

		for (int i = 0, z = 0; z <= zSize; z++)
		{
			for (int x = 0; x <= xSize; x++)
			{
				float y1 = Mathf.PerlinNoise(x * strength, z * strength) * 2f;
				float y2 = Mathf.PerlinNoise(x * strength, z * strength) * 5f;
				float y3 = Mathf.PerlinNoise(x * strength, z * strength) * 10f;
				float y4 = Mathf.PerlinNoise(x * strength, z * strength) * .8f;
				float y = (y1 + y2 + y3 + y4) / 4f;
				y *= Random.Range(0.5f, 1.5f);
				vertices[i] = new Vector3(x, y, z);
				if (y > maxHeight)
                {
					maxHeight = y;
                }
				if (y < minHeight)
				{
					minHeight = y;
				}
				i++;
			}
		}

		triangles = new int[xSize * zSize * 6];

		int vert = 0;
		int tris = 0;

		for (int z = 0; z < zSize; z++)
		{
			for (int x = 0; x < xSize; x++)
			{
				triangles[tris + 0] = vert + 0;
				triangles[tris + 1] = vert + xSize + 1;
				triangles[tris + 2] = vert + 1;
				triangles[tris + 3] = vert + 1;
				triangles[tris + 4] = vert + xSize + 1;
				triangles[tris + 5] = vert + xSize + 2;

				vert++;
				tris += 6;
			}
			vert++;
		}

		colors = new Color[vertices.Length];
		for (int i = 0, z = 0; z <= zSize; z++)
		{
			for (int x = 0; x <= xSize; x++)
			{
				float height = Mathf.InverseLerp(minHeight, maxHeight, vertices[i].y);
				colors[i] = grad.Evaluate(height);
				i++;
			}
		}
	}

	void UpdateMesh()
	{
		mesh.Clear();

		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.colors = colors; 

		mesh.RecalculateNormals();
	}

	void Update()
    {
		UpdateMesh();
    }
}