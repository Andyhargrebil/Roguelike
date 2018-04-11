using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class TreeDebug : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // TODO: Use the BinaryTree class to demonstrate its correctness
        BinaryTree<int> sampleTree = new BinaryTree<int>(42);

        BinaryTreeNode<int> left = sampleTree.Root().AddChild(5);
        BinaryTreeNode<int> right = sampleTree.Root().AddChild(17);

        left.AddChild(-6);
        left.AddChild(12);

        right.AddChild(128);
        right.AddChild(1024);

        BinaryTreeNode<int> treeRoot = sampleTree.Root();
        List<BinaryTreeNode<int>> leaves = new List<BinaryTreeNode<int>>();

        CollectLeaves(treeRoot, leaves);
        // At this point, <leaves> should contain all childless nodes in the tree.

        foreach (BinaryTreeNode<int> leaf in leaves)
        {
            print("Leaf found with value " + leaf.Value() + " and parent value " + leaf.parent.Value());
            int currentLeafSum = CountFromNodeToRoot(leaf);
            print("Sum to root is " + currentLeafSum);
        }


        /* Task: Find the sum from all leaf nodes.

        int leftOfLeftSum = CountFromNodeToRoot(leftofLeft);
        print("left of left sum: " + leftOfLeftSum);
        int rightOfLeftSum = CountFromNodeToRoot(rightofLeft);
        print("right of left sum: " + rightOfLeftSum);
        int leftOfRightSum = CountFromNodeToRoot(leftofRight);
        print("left of right sum: " + leftOfRightSum);
        int RightOfRightSum = CountFromNodeToRoot(rightofRight);
        print("right of right sum: " + RightOfRightSum);
        */
    }

    private void CollectLeaves(BinaryTreeNode<int> currentNode, List<BinaryTreeNode<int>> leaves)
    {
        if (currentNode == null) return;

        if (currentNode.IsLeaf())
            leaves.Add(currentNode);
        else
        {
            CollectLeaves(currentNode.leftChild, leaves);
            CollectLeaves(currentNode.rightChild, leaves);
        }
    }

    private int CountFromNodeToRoot(BinaryTreeNode<int> startNode)
    {
        BinaryTreeNode<int> current = startNode;
        int totalValue = 0;

        // While loops are dangerous because they can create inescapable loops.
        while(current != null)
        {
            totalValue += current.Value();
            current = current.parent;
            
        }

        return totalValue;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
