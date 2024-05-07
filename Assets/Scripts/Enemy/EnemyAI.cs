using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public Transform lifeItem;
    public Transform ammoItem;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireRate = 1f; // Tasa de disparo
    public int maxAmmo = 10; // Máximo de balas
    public float reloadTime = 2f; // Tiempo para recargar
    private int currentAmmo; // Balas actuales
    private float fireCooldown; // Enfriamiento para disparar

    private NavMeshAgent navMeshAgent;
    private FuzzyLogic fuzzyLogic;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        fuzzyLogic = GetComponent<FuzzyLogic>();
        currentAmmo = maxAmmo; // Inicia con el cargador lleno
    }

    void Update()
    {
        fireCooldown -= Time.deltaTime; // Disminuir enfriamiento

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        string action = fuzzyLogic.DecideAction(distanceToPlayer, currentAmmo, maxAmmo);

        switch (action)
        {
            case "MovPlayer":
                navMeshAgent.SetDestination(player.position);
                // Disparar si está cerca del jugador, hay munición y no hay enfriamiento
                if (distanceToPlayer < 10f && currentAmmo > 0 && fireCooldown <= 0)
                {
                    FireAtPlayer();
                }
                break;
            case "MovLife":
                navMeshAgent.SetDestination(lifeItem.position);
                break;
            case "MovAMMO":
                navMeshAgent.SetDestination(ammoItem.position);
                break;
            case "Huir":
                // Calcular dirección para huir
                Vector3 direction = (transform.position - player.position).normalized;
                Vector3 escapePosition = transform.position + direction * 10f; // Distancia para huir
                navMeshAgent.SetDestination(escapePosition);
                break;
        }
    }

    void FireAtPlayer()
    {
        // Crear bala y lanzarla hacia el jugador
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Vector3 direction = (player.position - bulletSpawnPoint.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = direction * 10f;
        currentAmmo--; // Reducir la munición actual
        fireCooldown = 1 / fireRate; // Restablecer el enfriamiento
    }

    // Método para recargar munición
    public void Reload()
    {
        currentAmmo = maxAmmo; // Rellenar el cargador
    }
}
