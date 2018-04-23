using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class TreeRectDebug : MonoBehaviour {

    public int levelWidth = 20;
    public int levelHeight = 20;
    public int splits = 5;
    System.Text.StringBuilder sb = new System.Text.StringBuilder();

    List<BinaryTreeNode<RectInt>> Leaves = new List<BinaryTreeNode<RectInt>>();

    private string[,] level;

    // Use this for initialization
    void Start() {

        level = new string[levelHeight, levelWidth];

        BinaryTree<RectInt> sampleRectTree = new BinaryTree<RectInt>(new RectInt(0, 0, levelWidth, levelHeight));

        RecursiveSplit(sampleRectTree.Root(), splits);
        RecursiveDive(sampleRectTree.Root());

        int counter = 1;
        foreach(BinaryTreeNode<RectInt> leaf in Leaves)
        {
            RectInt TheNode = NodeRectWorld(leaf);
            MakeRoom(TheNode, counter.ToString());
            counter++;
        }

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

        for (int i = region.y; i < region.y + region.height; ++i)
        {
            for (int j = region.x; j < region.x + region.width; ++j)
            {
                level[i, j] = value;
            }
        }
    }

    void RecursiveDive(BinaryTreeNode<RectInt> T)
    {
        if (T.IsLeaf())
        {
            Leaves.Add(T);
            return;
        }
        
        if (T.leftChild != null)
            RecursiveDive(T.leftChild);
        if (T.rightChild != null)
            RecursiveDive(T.rightChild);
    }

    private void HorSplit(BinaryTreeNode<RectInt> T)
    {
        RectInt current = T.Value();
        RectInt upperRect = new RectInt(0, 0, current.width, current.height / 2);
        RectInt lowerRect = new RectInt(0, current.height/2, current.width, current.height / 2);
        BinaryTreeNode<RectInt> upper = T.AddChild(upperRect);
        BinaryTreeNode<RectInt> lower = T.AddChild(lowerRect);
    }

    private void VerSplit(BinaryTreeNode<RectInt> T)
    {
        RectInt current = T.Value();
        RectInt leftRect = new RectInt(0, 0, current.width/2, current.height);
        RectInt rightRect = new RectInt(current.width/2, 0, current.width/2, current.height);
        BinaryTreeNode<RectInt> left = T.AddChild(leftRect);
        BinaryTreeNode<RectInt> right = T.AddChild(rightRect);
    }

    private void RecursiveSplit(BinaryTreeNode<RectInt> T, int numSplits)
    {
        if (numSplits == 0) return;

        if (numSplits % 2 == 1)
            VerSplit(T);
        else
            HorSplit(T);
        
        RecursiveSplit(T.leftChild, numSplits - 1);
        RecursiveSplit(T.rightChild, numSplits - 1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
