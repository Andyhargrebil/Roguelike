using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class TreeRectDebug : MonoBehaviour {

    public int levelWidth = 20;
    public int levelHeight = 20;
    System.Text.StringBuilder sb = new System.Text.StringBuilder();

    private string[,] level;

	// Use this for initialization
	void Start () {

        level = new string[levelHeight, levelWidth];

        BinaryTree<RectInt> sampleRectTree = new BinaryTree<RectInt>(new RectInt(0, 0, levelWidth, levelHeight));

        int partitionWidth = levelWidth / 2;
        int partitionHeight = levelHeight;

        RectInt leftPartitionRect = new RectInt(0, 0, partitionWidth, partitionHeight);
        BinaryTreeNode<RectInt> leftPartitionNode = sampleRectTree.Root().AddChild(leftPartitionRect);

        int rightPartitionX = levelWidth / 2;
        int rightPartitionY = 0;
        RectInt rightPartitionRect = new RectInt(rightPartitionX, rightPartitionY, partitionWidth, partitionHeight);
        BinaryTreeNode<RectInt> rightPartitionNode = sampleRectTree.Root().AddChild(rightPartitionRect);

        RectInt leftPartitionWorld = NodeRectWorld(leftPartitionNode);
        RectInt rightPartitionWorld = NodeRectWorld(rightPartitionNode);

        partitionHeight /= 2;
        RectInt upperLeftPartitionRect = new RectInt(0, 0, partitionWidth, partitionHeight);
        RectInt lowerLeftPartitionRect = new RectInt(0, partitionHeight, partitionWidth, partitionHeight);

        RectInt upperRightPartitionRect = new RectInt(0, 0, partitionWidth, partitionHeight);
        RectInt lowerRightPartitionRect = new RectInt(0, partitionHeight, partitionWidth, partitionHeight);

        BinaryTreeNode<RectInt> uLPartitionNode = leftPartitionNode.AddChild(upperLeftPartitionRect);
        BinaryTreeNode<RectInt> lLPartitionNode = leftPartitionNode.AddChild(lowerLeftPartitionRect);
        BinaryTreeNode<RectInt> uRPartitionNode = rightPartitionNode.AddChild(upperRightPartitionRect);
        BinaryTreeNode<RectInt> lRPartitionNode = rightPartitionNode.AddChild(lowerRightPartitionRect);

        RectInt upperLeftNode = NodeRectWorld(uLPartitionNode);
        RectInt lowerLeftNode = NodeRectWorld(lLPartitionNode);
        RectInt upperRightNode = NodeRectWorld(uRPartitionNode);
        RectInt lowerRightNode = NodeRectWorld(lRPartitionNode);

        print("Left: " + leftPartitionWorld);
        print("Right: " + rightPartitionWorld);

        print("upper left: " + upperLeftPartitionRect);
        print("lower left: " + lowerLeftPartitionRect);
        print("upper right: " + upperRightPartitionRect);
        print("lower right: " + lowerRightPartitionRect);

        print("upper left: " + upperLeftNode);
        print("lower left: " + lowerLeftNode);
        print("upper right: " + upperRightNode);
        print("lower right: " + lowerRightNode);

        MakeRoom(upperLeftNode, "1");
        MakeRoom(lowerLeftNode, "2");
        MakeRoom(upperRightNode, "3");
        MakeRoom(lowerRightNode, "4");

        for (int i = 0; i < levelHeight; i++)
        {
            for (int j = 0; j < levelWidth; j++)
            {
                sb.Append(level[i, j] + " ");
            }
            sb.AppendLine();
        }
        print(sb.ToString());

        
        
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

    private void MakeRoom(RectInt region, string value)
    {
        // TODO: Set the values of level[,] that are inside
        // the area specified by RectInt region

        for(int i = region.y; i < region.y + region.height; ++i)
        {
            for(int j = region.x; j < region.x + region.width; ++j)
            {
                level[i, j] = value;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
