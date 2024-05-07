using UnityEngine;

public class FuzzyLogic : MonoBehaviour
{
    public float FuzzifyDistance(float distance)
    {
        if (distance < 2f) // Muy cerca
            return 1f;
        else if (distance < 5f) // Cerca
            return 0.5f;
        else // Lejos
            return 0f;
    }

    public float FuzzifyLife(float life)
    {
        if (life < 20f) // Baja
            return 1f;
        else if (life < 50f) // Media
            return 0.5f;
        else // Alta
            return 0f;
    }

    public float FuzzifyAmmo(float ammo)
    {
        if (ammo < 5f) // Baja
            return 1f;
        else if (ammo < 15f) // Media
            return 0.5f;
        else // Alta
            return 0f;
    }

    public string DecideAction(float distance, float life, float ammo)
    {
        float distanceFuzzy = FuzzifyDistance(distance);
        float lifeFuzzy = FuzzifyLife(life);
        float ammoFuzzy = FuzzifyAmmo(ammo);

        if (distanceFuzzy == 1f) // Muy cerca del jugador
        {
            return "Huir";
        }
        else if (lifeFuzzy == 1f) // Vida baja
        {
            return "MovLife";
        }
        else if (ammoFuzzy == 1f) // Munición baja
        {
            return "MovAMMO";
        }
        else // Moverse hacia el jugador
        {
            return "MovPlayer";
        }
    }
}
