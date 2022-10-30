using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour {

	private NavMeshAgent _agent;
    private Animator _animator;
    private Vector3 _lastGoal;
    private float pickUpChance = 0.05f;


	// Use this for initialization
	private void Start () 
	{
		_agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _animator.SetBool("isWalking", true);
        PickGoalLocation();
	}

	private void PickGoalLocation()
    {
        _lastGoal = _agent.destination;
        _agent.SetDestination(GameEnvironment.Instance.GetRandomGoalLocation().position);
    }

	
	private void Update () {
        if (_agent.remainingDistance < 1) //At the goal
        {
            PickGoalLocation();
        }

        foreach (GameObject obstacle in GameEnvironment.Instance.Obstacles)
        {
	        var distance = Vector3.Distance(obstacle.transform.position,transform.position);
	        if (distance < 4f && Random.Range(0f,1f) < pickUpChance)
	        {
		        _agent.SetDestination(_lastGoal);
	        }
	        else if (distance < 2f)
	        {
		        GameEnvironment.Instance.RemoveObstacle(obstacle);
		        break;
	        }
        }
	}
}
