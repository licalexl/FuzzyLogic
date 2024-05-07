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
                enemyAI.Reload(); // Recargar munici�n
                Destroy(gameObject); // Destruir el objeto de munici�n tras recogerlo
            }
        }
    }
}
