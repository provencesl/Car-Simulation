using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using PathCreationEditor;


public class Road : MonoBehaviour
{

    public bool closedLoop = true;
    public Mesh _roadMesh;

    public List<Transform> waypoints;

    [SerializeField] private int _spwanLength = 10;

    private float _zLength = 0;

    void Start()
    {
        IntialSpwan();
    }


    public void GeneratePath()
    { 
        // remove first half waypoints
        for(int i = 0; i < (_spwanLength/2); i++)
        {
            Transform waypoint = waypoints[0];
            waypoints.RemoveAt(0);
            Destroy(waypoint.gameObject);
        }

        for (int i = 0; i < (_spwanLength/2); i++)
        {
            var waypoint = new GameObject();
            float x = Random.Range(-4, 4) * 5;
            _zLength = _zLength + Random.Range(1, 6) * 5;
            waypoint.transform.position = new Vector3(x, 5, _zLength);
            waypoints.Add(waypoint.transform);
        }

        BezierPath bezierPath = new BezierPath(waypoints, false, PathSpace.xyz);
        GetComponent<PathCreator>().bezierPath = bezierPath;

    }


    private void IntialSpwan()
    {

        for( int i = 0; i < _spwanLength; i++)
        {
            var waypoint = new GameObject();
            float x = Random.Range(-4, 4) * 10;
            _zLength = _zLength + Random.Range(1, 6) * 10;
            waypoint.transform.position = new Vector3(x, 0, _zLength);
            waypoints.Add(waypoint.transform);

        }

        BezierPath bezierPath = new BezierPath(waypoints, closedLoop, PathSpace.xyz);
        GetComponent<PathCreator>().bezierPath = bezierPath;


    }
}
