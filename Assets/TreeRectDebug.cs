using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class TreeRectDebug : MonoBehaviour {

    public int levelWidth = 20;
    public int levelHeight = 20;

	// Use this for initialization
	void Start () {
        BinaryTree<RectInt> sampleRectTree = new BinaryTree<RectInt>(new RectInt(0, 0, 20, 20));

        int partitionWidth = levelWidth / 2;
        int parttionHeight = levelHeight;

        RectInt leftPartitionRect = new RectInt(0, 0, partitionWidth, parttionHeight);
        BinaryTreeNode<RectInt> leftPartitionNode = sampleRectTree.Root().AddChild(leftPartitionRect);

        int rightPartitionX = levelWidth / 2;
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
}
