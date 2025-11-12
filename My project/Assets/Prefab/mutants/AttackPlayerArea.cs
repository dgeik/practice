using UnityEngine;

public class AttackPlayerArea : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.GetComponent<Enemy>().isAttack = true;
            enemy.GetComponent<Enemy>().state = Enemy.States.Attack;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.GetComponent<Enemy>().isAttack = false;
            enemy.GetComponent<Enemy>().state = Enemy.States.Idle;
        }
    }
}
