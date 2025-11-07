using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class arrowtower : MonoBehaviour
{
    [SerializeField]private float shootrange = 1.5f;
    [SerializeField]private float cooldown = 1.5f;
    [SerializeField]private Animator animator;
    // Update is called once per frame
    [SerializeField]private GameObject bullet;
    void Update()
    {
        cooldown -= Time.deltaTime;

            enemy furthestEnemy = null;
            float furthestDistance = float.MinValue;
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, shootrange);
            foreach (Collider2D hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("enemy"))
                {
                    enemy enemyComponent = hitCollider.GetComponent<enemy>();
                    if (enemyComponent != null && enemyComponent.howfar > furthestDistance)
                    {
                        furthestDistance = enemyComponent.howfar;
                        furthestEnemy = enemyComponent;
                    }
                }
            }
            if (furthestEnemy != null)
            {
                if (cooldown >= 0)
                {
                shoot(furthestEnemy.transform.position);
                cooldown = 1.5f;
                }
            return;
            }
        
    }
    public void shoot(Vector3 Target)
    {
        animator.Play("1_Clip");

        var direction = Vector3.Angle(transform.position, Target);
        var arrowbullet = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0,0, direction)));
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootrange);
    }
}
