using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindDirectionIndicator : MonoBehaviour
{

    [SerializeField] private ParticleSystemForceField psff;
    [SerializeField] private float windSpeedMultiplier = 1;

    public void ChangeDirection(float angle, float windSpeed)
    {
        //Quaternion rotation = Quaternion.Euler(0f, angle, 0f);

        //transform.rotation = rotation;

        float radians = angle * Mathf.PI / 180f;

        float x = Mathf.Sin(radians);
        float z = Mathf.Cos(radians);

        Vector2 direction = new Vector2(x, z).normalized;
        x = direction.x;
        z = direction.y;

        x *= windSpeed * windSpeedMultiplier;
        z *= windSpeed * windSpeedMultiplier;

        psff.directionX = x;
        psff.directionZ = z;


        Debug.Log("windSpeed = " + windSpeed);
        Debug.Log("Mathf.Sin(radians) = " + Mathf.Sin(radians));
        Debug.Log("Mathf.Cos(radians) = " + Mathf.Cos(radians));

        // Debug.Log("L'indicateur de direction a changé d'orientation. Son angle est de : " + angle + "°.");
    }
}
