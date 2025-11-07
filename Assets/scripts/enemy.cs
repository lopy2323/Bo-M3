using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private int health = 1;
    private int currentWaypointIndex = 0;
    public float howfar { get; private set; } = 0f;
    public static event Action loselife;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
       if (GameMAneger.instance.waypoints.Count == 0 || GameMAneger.instance.waypoints == null)
        {
            return;
        }
       Transform target = GameMAneger.instance.waypoints[currentWaypointIndex];
       Vector3 Previouspostion = transform.position;
       transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        howfar += Vector3.Distance(Previouspostion, transform.position);
         if (Vector3.Distance(transform.position, target.position) < 0.1f)
          {
                currentWaypointIndex++;
                if (currentWaypointIndex >= GameMAneger.instance.waypoints.Count)
                {
                loselife.Invoke();
                Destroy(gameObject);
                return;
                }
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"Enemy took {damage} damage, health now {health}");
        if (health <= 0)
        {
            Debug.Log("Destroying enemy");
            Destroy(gameObject);
            UI.instance.addmana(10);

            Debug.Log("Enemy destroyed");
        }
    }
}
