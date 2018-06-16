using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public int Health;
    public float ActionPoints;
    public float ActivationDistance;
    public GameObject DestinationObject;

    private bool active;
    private Vector3 lastPosition;

    private void Start ()
    {

        SetActive(false);
        lastPosition = transform.position;
    }
	
	private void Update ()
    {
        if (active) {
            var agent = GetComponent<NavMeshAgent>();
            Debug.Log(DestinationObject.transform.position);
            agent.enabled = ActionPoints > 0.0f;
            if (agent.enabled)
                agent.SetDestination(DestinationObject.transform.position);

            ActionPoints -= (lastPosition - transform.position).magnitude;
            lastPosition = transform.position;
            ActionPoints = Mathf.Max(0.0f, ActionPoints);
        }
	}

    public void SetActive(bool newActive)
    {
        GetComponent<NavMeshAgent>().enabled = newActive;
        active = newActive;
    }

    public bool GetActive()
    {
        return active;
    }
}
