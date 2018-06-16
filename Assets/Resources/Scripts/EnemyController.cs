using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public int Health;
    public float ActionPoints;
    public float ActivationDistance;
    public float AttackDistance;
    public float AttackPrice;
    public float AttackInterval;
    public float Damage;
    public GameObject DestinationObject;
    public GameObject GameState;

    private bool active;
    private Vector3 lastPosition;
    private float lastShotTime = 0.0f;

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
            var flatPosition = new Vector2(transform.position.x, transform.position.z);
            var flatDestinationPosition = new Vector2(DestinationObject.transform.position.x, DestinationObject.transform.position.z);
            var canAttack = (flatPosition - flatDestinationPosition).magnitude < AttackDistance;
            agent.enabled = ActionPoints > 0.0f && !canAttack;
            if (agent.enabled)
                agent.SetDestination(DestinationObject.transform.position);

            ActionPoints -= (lastPosition - transform.position).magnitude;
            lastPosition = transform.position;
            ActionPoints = Mathf.Max(0.0f, ActionPoints);

            var now = Time.time;
            if (ActionPoints > 0.0f && canAttack && lastShotTime + AttackInterval <= now) {
                GameState.GetComponent<GameStateController>().Health -= Damage;
                lastShotTime = now;
                ActionPoints -= AttackPrice;
                Debug.Log("Attack");
            }
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
