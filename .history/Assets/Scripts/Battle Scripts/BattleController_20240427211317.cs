public class BattleController : MonoBehaviour
{
    public GameObject BattleEndCanvas;
    public bool allEnemiesDead;
    private List<GameObject> enemies;

    void Start()
    {
        // Find all enemies at the start and store them in the list
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    void Update()
    {
        allEnemiesDead = areAllEnemiesDead();
    }

    public bool areAllEnemiesDead()
    {
        // Iterate through the cached enemy list
        foreach (GameObject enemy in enemies)
        {
            if (enemy == null) 
            {
                // Remove destroyed enemies from the list
                enemies.Remove(enemy);
            }
            else if (enemy.GetComponent<Attributes>().alive)
            {
                return false;
            }
        }
        return true;
    }
}