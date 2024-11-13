using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapScript : MonoBehaviour
{
    //creating the tilemap and tilebases for the player, chests, walls and doors.
    public Tilemap Tilemap;
    public TileBase Wall;
    public TileBase Player;
    public TileBase Chest;
    public TileBase Door;
    
    //Creating the x and y sizes of the map
    int[,] Map = new int[15, 10];
   
    private void Start()
    {
        LoadPremadeMap();
    }

    //The method for generating the string of the map.
    string GenerateMap(int width, int height)
    {
        //declaring a character array and passing perameters into it.
        char[,] Map = new char[width, height];
       
        //Characters for drawing the different tiles in the game.
        char walls = '%';
        char ground = '@';
        char player = 'O';
        //char chest = 'C';
        char door = 'D';
        //Integer of a random Y position for the placement of the doors on the height.
        int randomYposition = Random.Range(1, height - 3);
        //Integer of a random X position for the placement of the doors on the width.
        int randomXposition = Random.Range(1, width - 3);
       
        //Runs for every iteration of inside width loop and draws the width.
        for (int y = 0; y < height; y++)
        {
            //runs for every iteration of the outer height loop.
            for (int x = 0; x < width; x++)
            {
                //Assigns and draws the ground with its character in the console.
                Map[x, y] = ground;

                //conditional statement/ rule that generates walls around the border of the play area.
                if (x == width - 1 || y == height - 1 || y == 0 || x == 0)
                {
                    //Assigns and draws the wall characters around the borders of the ground.
                    Map[x, y] = walls;
                }
                //Another conditional statement/rule that generates doors around the inside of the walls.
                else if (x == width - 2 && y == randomYposition || y == height - 2 && x == randomXposition)
                {
                    //Assigns the door character to the space it gets generated to.
                    Map[x, y] = door;
                }

            }

               
        
        }


        //An instance of stringbuilder to build the map.
        StringBuilder MapString = new StringBuilder();

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                //Appends each character of the map to a string.
                MapString.Append(Map[x, y]);

            }

            //Appended each character to the map builder.
            MapString.AppendLine();

        }

        //Returns the Map string to the return value of the method.
        return MapString.ToString();

    }
    
    //The method for drawing the Tilemap.
   void ConvertToTileMap(string mapData)
    {
        for (int y = 0; y < Map.GetLength(1); y++)
        {
            for (int x = 0; x < Map.GetLength(0); x++)
            {
                Vector3Int Cellposition = new Vector3Int(x, y, 0);
                if (Map[x,y] == 1)
                {
                    Tilemap.SetTile(Cellposition, Wall);
                }

            }
        }
    }

    //Method that loads a premade map from a text file.

    public char[,] multidimensionalArray = new char[15, 10];
    void LoadPremadeMap()
    {
        //For accessing the text file in Unity.
        string pathToMyFile = $"{Application.dataPath}/TextFiles/PreMadeMap.txt";
        
        //Allows the text file to be read in Unity.
        string[] myLines = System.IO.File.ReadAllLines(pathToMyFile);
       

        for(int y = 0; y < myLines.Length; y++)
        {
            string myLine = myLines[y];
            
            for(int x = 0; x < myLine.Length; x++)
            {
                char myChar = myLine[x];
                
                if(x < multidimensionalArray.GetLength(0) && y< multidimensionalArray.GetLength(1))
                {
                    multidimensionalArray[x, y] = myChar;
                }
            }
        }

        Debug.Log(multidimensionalArray[2, 0]);
        Debug.Log(multidimensionalArray[3, 2]);

    }
 
  
}
