using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour
{
    [SerializeField]
    private GameObject cubePrefab;

    [SerializeField]
    private int iteration;

    [SerializeField]
    private float size;

    List<GameObject> cubes = new List<GameObject>();

    void Start()
    {
        //  This statement create a game object given a prefab, position and rotation.
        GameObject cube =  Instantiate(cubePrefab, Vector3.zero, Quaternion.identity);
        cube.transform.localScale = new Vector3(size, size, size);
        cubes.Add(cube);
    }

    void Update()
    {
        if (iteration > 1)
        {
            List<GameObject> newCubes = Split(cubes);

            foreach (var cube in cubes)
            {
                Destroy(cube);
            }

            cubes = newCubes;
        }
    }

    List<GameObject> Split(List<GameObject> cubes)
    {
        List<GameObject> subCubes = new List<GameObject>();

        foreach(var cube in cubes)
        {

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    for (int z = 0; z < 3; z++)
                    {
                        float xx = x * (size);
                        float yy = y * (size);
                        float zz = z * (size);

                        Vector3 cubePos = new Vector3(xx, yy, zz) + cube.transform.position;
                        
                        GameObject copy = Instantiate(cube, cubePos, Quaternion.identity);
                        copy.transform.localScale = new Vector3(size, size, size);
                    }
                }
            }
        }


        return subCubes;
    }
}
