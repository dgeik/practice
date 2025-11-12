using UnityEngine;

public class SeePlayerArea : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && enemy.GetComponent<Enemy>().isAttack == false)
        {
            enemy.GetComponent<Enemy>().state = Enemy.States.Chase;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.GetComponent<Enemy>().state = Enemy.States.Idle;
        }
    }
}
