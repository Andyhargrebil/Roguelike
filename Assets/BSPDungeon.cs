using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSPDungeon : MonoBehaviour
{
    int height = 9;
    int width = 9;
    string[,] level;
    Room leftRoom = new Room();
    Room rightRoom = new Room();
    HorCorridor bridge = new HorCorridor();
    System.Text.StringBuilder sb = new System.Text.StringBuilder();

    // Use this for initialization
    void Start()
    {
        level = new string [height, width];
        Split();
        MakeRooms();
        ConnectRooms();

        MakeLevel();
        DrawLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Split()
    {
        Partition leftPartition = new Partition();
        leftPartition.top = height - 1;
        leftPartition.left = 0;
        leftPartition.width = width / 2;
        leftPartition.height = height - 1;
        
        Partition rightPartition = new Partition();
        rightPartition.top = height - 1;
        rightPartition.left = width / 2;
        rightPartition.width = width / 2;
        rightPartition.height = height - 1;
    }

    void MakeRooms()
    {
        leftRoom.top = height - 2;
        leftRoom.left = 1;
        leftRoom.width = width / 2 - 2;
        leftRoom.height = height - 2;

        rightRoom.top = height - 2;
        rightRoom.left = width / 2 + 1;
        rightRoom.width = width / 2 - 2;
        rightRoom.height = height - 2;
    }

    void ConnectRooms()
    {
        bridge.top = height / 2;
        bridge.left = width / 2 - 1;
        bridge.width = 2;
    }

    void MakeLevel()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (i <= leftRoom.top && i > leftRoom.top - leftRoom.height && j >= leftRoom.left && j<= leftRoom.width + leftRoom.left)
                {
                    level[i, j] = "L";
                } else if (i <= rightRoom.top && i > rightRoom.top - rightRoom.height && j >= rightRoom.left && j <= rightRoom.width + rightRoom.left)
                {
                    level[i, j] = "R";
                } else if (i == bridge.top && j >= bridge.left && j <= bridge.left + bridge.width)
                {
                    level[i, j] = "C";
                }
                else { level[i, j] = "E"; }
            }
        }
    }

    void DrawLevel()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                sb.Append(level[i, j]);
            }
            sb.AppendLine();
        }
        print(sb.ToString());
    }
}

public class Partition
{
    public int top, left, width, height;
}

public class Room
{
    public int top, left, width, height;
}

public class HorCorridor
{
    public int left, top, width;
}

public class VerCorridor
{
    public int left, top, height;
}
