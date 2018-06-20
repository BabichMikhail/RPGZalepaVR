using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject GameState;

    public void Fire()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + transform.forward * 0.1f, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, 255)) {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue, 2.0f);
            var targetObject = hit.transform.gameObject;
            var enemyController = targetObject.GetComponent<EnemyController>();
            if (enemyController != null) {
                enemyController.Health -= 1;
            }
            Debug.Log(hit.transform.gameObject);
            Debug.Log("Did Hit");
        }
        else {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100000, Color.red, 2.0f);
            Debug.Log("Did not Hit");
        }

        var projectileController = GetComponentInChildren<AmmunitionController>();
        if (projectileController != null)
            --projectileController.ProjectilesLeft;
    }

    public int GetCurrentProjectileCount()
    {
        var projectileController = GetComponentInChildren<AmmunitionController>();
        return projectileController == null ? 0 : projectileController.ProjectilesLeft;
    }
}
