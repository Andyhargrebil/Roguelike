using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class ArrayPractice : MonoBehaviour {

    public int height = 20;
    public int width = 20;
    int[,] level;
    System.Text.StringBuilder sb = new System.Text.StringBuilder();

	// Use this for initialization
	void Start () {
        level = new int[height, width];

        BinaryTree<RectInt> sampleRectTree = new BinaryTree<RectInt>(new RectInt(0, 0, 20, 20));

        int partitionWidth = width / 2;
        int parttionHeight = height;

        RectInt leftPartitionRect = new RectInt(0, 0, partitionWidth, parttionHeight);
        BinaryTreeNode<RectInt> leftPartitionNode = sampleRectTree.Root().AddChild(leftPartitionRect);

        int rightPartitionX = width / 2;
        int rightPartitionY = 0;
        RectInt rightPartitionRect = new RectInt(rightPartitionX, rightPartitionY, partitionWidth, parttionHeight);
        BinaryTreeNode<RectInt> rightPartitionNode = sampleRectTree.Root().AddChild(rightPartitionRect);

        RectInt leftPartitionWorld = NodeRectWorld(leftPartitionNode);
        RectInt rightPartitionWorld = NodeRectWorld(rightPartitionNode);

        print("Left: " + leftPartitionWorld);
        print("Right: " + rightPartitionWorld);
    }

    private RectInt NodeRectWorld(BinaryTreeNode<RectInt> node)
    {
        BinaryTreeNode<RectInt> current = node;
        RectInt rectWorld = node.Value();
        rectWorld.x = 0;
        rectWorld.y = 0;
        while (current != null)
        {
            rectWorld.x += current.Value().x;
            rectWorld.y += current.Value().y;
            current = current.parent;
        }
        return rectWorld;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void MakeLevel()
    {
        for (int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                level[i, j] = (i * width + j) % 10;
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
