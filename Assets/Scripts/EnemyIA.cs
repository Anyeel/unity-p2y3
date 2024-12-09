using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    private Vector3 movementInput;
    [SerializeField] float speed;
    [SerializeField] float minSpeed = 5f;
    [SerializeField] float maxSpeed = 7f;
    private float differenceMinMaxSpeed;
    [SerializeField] float damage = 10;
    [SerializeField] float fleeingSpeed;
    [SerializeField] float fleeingSpeedDivisor = 10;
    [SerializeField] Gradient bodyColor;
    [SerializeField] float spawnColor;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] ParticleSystem particleSystemA;
    Health health;


    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        speed = Random.Range(minSpeed, maxSpeed);
        fleeingSpeed = speed / fleeingSpeedDivisor;
        differenceMinMaxSpeed = maxSpeed - minSpeed;
        spawnColor = (speed - minSpeed) / differenceMinMaxSpeed;
        spriteRenderer.color = bodyColor.Evaluate(spawnColor);
        ParticleSystem.MainModule main = particleSystemA.main;
        main.startColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mainCharacterPosition = health.gameObject.transform.position;

        movementInput = (mainCharacterPosition - transform.position);

        movementInput = movementInput.normalized;

        transform.position += speed * movementInput * Time.deltaTime * (!health.IsDead() ? 1 : -fleeingSpeed);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            collision.collider.gameObject.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }


}
