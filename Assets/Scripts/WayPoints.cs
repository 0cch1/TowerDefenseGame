using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static WayPoints instance { get; private set; }
    // List to store all waypoints
    private List<Transform> waypointList;

    private void Awake()
    {
        instance = this;
        Init();
    }
  

    private void Init()
    {
        // Get all child transform components of this object (but remove the parent itself)
        Transform[] transforms = transform.GetComponentsInChildren<Transform>();
        waypointList = new List<Transform>(transforms);
        waypointList.RemoveAt(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to get the number of waypoints in the list
    public int GetLength()
    {
        return waypointList.Count;
    }
    
    // Method to get the position of a waypoint at a specific index
    public Vector3 GetWayPoint(int index)
    {
        return waypointList[index].position;
    }
}
