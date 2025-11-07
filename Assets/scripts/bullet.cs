using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float speed = 5f;
    [SerializeField] private int damage = 1;

    private void FixedUpdate()
    {
        Vector3 move = transform.right * speed * Time.fixedDeltaTime;
        transform.position += move;
    }
}
