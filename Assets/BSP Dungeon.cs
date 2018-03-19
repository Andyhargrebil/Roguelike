using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSPDungeon : MonoBehaviour {
    int height = 20;
    int width = 20;
    int[,] level = new int[20,20];

	// Use this for initialization
	void Start () {
        Split();
        MakeRooms();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Split ()
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
        Room leftRoom = new Room();
        leftRoom.top = height - 2;
        leftRoom.left = 1;
        leftRoom.width = width / 2 - 2;
        leftRoom.height = height - 2;

        Room rightRoom = new Room();
        rightRoom.top = height - 1;
        rightRoom.left = width / 2 + 1;
        rightRoom.width = width / 2 - 2;
        rightRoom.height = height - 2;
    }

    void ConnectRooms()
    {
        HorCorridor bridge = new HorCorridor();
        bridge.top = height / 2;
        bridge.left = width / 2 - 1;
        bridge.width = 2;
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
