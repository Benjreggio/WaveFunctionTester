using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
using static Util;
//using WaveFunctionCollapser;

public class SpawnCubes : MonoBehaviour
{
    public GameObject bluecube;
    public GameObject redcube;
    public GameObject yellowcube;
    public GameObject greencube;
    public GameObject purplecube;
    public GameObject orangecube;

    public int[,] places;

    public int width;
    public int height;
    public int depth;
    public int options = 6;

    public int i = 0;

    // Use this for initialization
    void Start()
    {
        places = new int[width*height*depth,3];
        //Spawn(0, 0, 0, 0);
        //InvokeRepeating("makeRandom", 1,1);
        int[,,] grid = makeRandom2();

        try
        {
            if (File.Exists("Assets/Resources/rules.txt"))
            {
                StreamReader sr = new StreamReader("Assets/Resources/rules.txt");
                bool[,] matRules = GetRules(sr);
                Debug.Log(ArrayToString(matRules));
                Tobject t = new Tobject();
                //Debug.Log(t.getWords());
                //WaveFunctionCollapser wfc = new WaveFunctionCollapser(matRules);
                //int[] weights = new int[] { 1, 1, 1, 1, 1, 1 };
                //wfc.makeGrid(weights,new int[] { width, height, depth });
            }
            else
            {
                Debug.Log("File not found");
            }
        }
        catch
        {
            SpawnGrid(grid);
            Debug.Log("Fail");
        }
    }

    void makeRandom()
    {
        var randx = new System.Random();
        int x = (int)randx.Next(width);
        int y = (int)randx.Next(height);
        int z = (int)randx.Next(depth);
        int c = (int)randx.Next(options);
        int[] place = new int[] { x, y, z };
        System.Console.WriteLine(Contains(places,place));
        Debug.Log("Hi");
        int tries = 0;
        while (Contains(places,place) & (tries < 1000))
        {
            x = randx.Next(width);
            y = randx.Next(height);
            z = randx.Next(depth);
            c = (int)randx.Next(options);
            place = new int[] { x, y, z };
            if (Contains(places, place))
            {
                Spawn(-1, -1, -1, 1);
            }
            tries = tries + 1;
        }
        if (Contains(places, place))
        {
            Spawn(-1, -1, -1, 1);
        }
        else
        {
            Spawn(-2, -2, -2, 2);
        }
        Debug.Log(ArrayToString(place));
        for(int j = 0;  j < place.Length; j++)
        {
            places[i,j] = place[j];
        }
        Debug.Log(ArrayToString(places));
        i =i+1;
        Spawn(x, y, z, c);
    }

    int[,,] makeRandom2()
    {
        var randx = new System.Random();
        int c;
        int[,,] grid = new int[width, height, depth];
        for(int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                for (int z = 0; z < depth; z++)
                {
                    c = (int)randx.Next(options);
                    grid[x, y, z] = c;
                }
            }
        }
        return grid;
    }

    void SpawnGrid(int[,,] grid)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                for (int z = 0; z < depth; z++)
                {
                    Spawn(x, y, z, grid[x, y, z]);
                }
            }
        }
    }

    GameObject intToPrefab(int i)
    {
        GameObject[] prefabs = new GameObject[] { bluecube, purplecube, redcube, orangecube, yellowcube, greencube };
        return prefabs[i];
    }

    void Spawn(int x, int y, int z, int i)
    {
        // Instantiate the cube at (x, y,z)
        Instantiate(intToPrefab(i),
                    new Vector3(x, y, z),
                    Quaternion.identity); // default rotation
    }
}
