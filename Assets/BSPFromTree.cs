using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSPFromTree : MonoBehaviour {

    int height = 8;
    int width = 8;
    string[,] level;
    Room test = new Room();
    System.Text.StringBuilder sb = new System.Text.StringBuilder();

    // Use this for initialization
    void Start () {
        level = new string[height, width];
        test.left = 3;
        test.top = 2;
        test.width = 4;
        test.height = 3;

        for(int i = test.top; i < test.top + test.height; ++i)
        {
            for(int j = test.left; j < test.left + test.width; ++j)
            {
                level[i, j] = "F";
            }
        }

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (level[i, j] != "F")
                    level[i, j] = "E";
            }
        }

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                sb.Append(level[i, j] + " ");
            }
            sb.AppendLine();
        }
        print(sb.ToString());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}