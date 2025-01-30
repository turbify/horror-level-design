using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSpriteOnProximity : MonoBehaviour
{
    [Header("Player Settings")]
    public Transform player; // Assign the player's transform in the Inspector

    [Header("Proximity Settings")]
    public float triggerDistance = 5f; // Distance at which the sprite starts appearing
    public float fadeSpeed = 2f; // Speed of the fade-in effect

    private SpriteRenderer spriteRenderer;
    private float targetAlpha = 0f; // Desired alpha value

    private void Start()
    {
        // Get the SpriteRenderer component attached to the object
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("No SpriteRenderer found on the object. Please attach a SpriteRenderer component.");
        }
    }

    private void Update()
    {
        if (spriteRenderer == null || player == null) return;

        // Calculate distance between player and this object
        float distance = Vector3.Distance(player.position, transform.position);

        // Set target alpha based on proximity
        if (distance <= triggerDistance)
        {
            targetAlpha = 1f; // Fully visible
        }
        else
        {
            targetAlpha = 0f; // Fully transparent
        }

        // Smoothly interpolate the alpha value
        Color color = spriteRenderer.color;
        color.a = Mathf.Lerp(color.a, targetAlpha, Time.deltaTime * fadeSpeed);
        spriteRenderer.color = color;
    }
}
