using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Description: This scripts creates a randomly generated cave out of objects given to it.
 *              The object it uses the generate the cave must be uniform in size of equal scale
 *              in length and height. The object this script is place on will be the bottom left corner of the map.
 *              
 * Variables: GameObject mapComponent: Stores the object this function duplicates to make the map out of.
 *            float mapComponentSize: Stores the size of the map component.
 *            int width: Stores the width of the map this is measured in the number of mapComponents you wish the map to be made out off
 *            int height: Stores the height of the mpa this is measured in the number of mapComponents you wish the map to be made out off
 *            float layer: Stores the z axis of the object to ensure it is infront of all other objects
 *            int[,] grid: This varable holds a grids of 0,1 of the size width x height a zero represents an empty space and a 1 represents 
 *                         a map component in a given location.
 *            int randomFillPercent: The variable represents the percentage chance any space on the map will initially be filled with a mapComponents.
 */


public class MapGenerator : MonoBehaviour
{
    // Stores the object that the map is made of
    public GameObject mapComponent;

    // stores size/scale of map component
    public float mapComponentSize = 1;

    // Stores the range of this map
    public int width = 0;
    public int height = 0;

    // stores layer the object is on
    public float layer;

    // stores an array representing the map
    private int[,] grid;

    // stores the percent of the map that will be filled
    private int randomFillPercent;

    // Start is called before the first frame update
    void Start()
    {
        randomFillPercent = 5;
        grid =  new int[width, height];

        GenerateMap();
    }

    // Randomly adds values to the grid based on the randomFillPercent value
    void randomFillGrid()
    {
        for (int x = 0; x < width; x++) 
        {
            for (int y = 0; y < height; y++)
            {
                // the bottom 1/4 is always filled
                if (y < (height / 4)) 
                {
                    grid[x, y] = 1;
                }
                
                else if (Random.Range(1, 101) < (randomFillPercent - (y - height)))
                {
                    grid[x, y] = 1;
                }
                else
                {
                    grid[x, y] = 0;
                }
            }
        }
    }

    void GenerateMap() 
    {
        randomFillGrid();

        for (int i = 0; i < 3; i++) 
        {
            CleanMap();
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (grid[x, y] == 1)
                {
                    Vector3 position = new Vector3(this.transform.position.x + x * mapComponentSize,
                        this.transform.position.y + y * mapComponentSize, layer);
                    Instantiate(mapComponent, position, mapComponent.transform.rotation);
                }
            }
        }
    }

    void CleanMap() 
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int surroundingComponentes = CountSurroundingComponents(x, y);
                
                if (surroundingComponentes >= 4)
                {
                    grid[x, y] = 1;
                } 
                else if (surroundingComponentes < 4)
                {
                    grid[x, y] = 0;
                }
                
            }
        }
    }

    int CountSurroundingComponents(int x, int y) 
    {
        int count = 0;
        for (int surroundingX = x - 1; surroundingX <= x + 1; surroundingX++) 
        {
            for (int surroundingY = y - 1; surroundingY <= y + 1; surroundingY++)
            {
                if (surroundingX >= 0 && surroundingX < width && surroundingY >= 0 && surroundingY < height)
                {
                    if (grid[surroundingX, surroundingY] == 1)
                    {
                        count += 1;
                    }
                }
            }
        }

        return count;

    }
}
