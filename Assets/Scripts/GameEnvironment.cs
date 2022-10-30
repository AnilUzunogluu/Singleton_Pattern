using System.Collections.Generic;
using UnityEngine;

public sealed class GameEnvironment
{
    private static GameEnvironment _instance;

    private List<GameObject> _goalLocations = new List<GameObject>();
    private List<GameObject> _obstacles = new ();
    public List<GameObject> Obstacles => _obstacles;
    public List<GameObject> GoalLocations => _goalLocations;

    public static GameEnvironment Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameEnvironment();
                _instance._goalLocations.AddRange(GameObject.FindGameObjectsWithTag("goal"));
            }

            return _instance;
        }
    }

    public Transform GetRandomGoalLocation()
    {
        return GoalLocations[Random.Range(0, GoalLocations.Count)].transform;
    }

    public void AddObstacle(GameObject obj)
    {
        _obstacles.Add(obj);
    }

    public void RemoveObstacle(GameObject obj)
    {
        int index = _obstacles.IndexOf(obj);
        _obstacles.RemoveAt(index);
        Object.Destroy(obj);
    }
}
