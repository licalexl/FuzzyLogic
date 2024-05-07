using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemyAI = other.GetComponent<EnemyAI>();
            if (enemyAI != null)
            {
                enemyAI.Reload(); // Recargar munición
                Destroy(gameObject); // Destruir el objeto de munición tras recogerlo
            }
        }
    }
}
