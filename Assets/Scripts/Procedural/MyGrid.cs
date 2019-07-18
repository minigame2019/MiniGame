using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MyGridGraph : GridGraph
{
    public float[,] noiseMap;
    public float seaLevel;
    public override void RecalculateCell(int x, int z, bool resetPenalties = true, bool resetTags = true)
    {
        var node = nodes[z * width + x];
        // Set the node's initial position with a y-offset of zero
        node.position = GraphPointToWorld(x, z, 0);
        int posx = node.position.x;
        //int posx = node.position.x;
        int posz = node.position.z;
        node.Walkable = noiseMap[posx, posz] <= seaLevel? false : true;
        node.Tag = 0;
        // Store walkability before erosion is applied
        // Used for graph updates
        node.WalkableErosion = node.Walkable;
    }
}