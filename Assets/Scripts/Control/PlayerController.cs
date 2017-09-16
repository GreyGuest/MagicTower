using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8.0f;
    public float gravity = 20.0f;
    public float jumpValue = 6.0f;
    private Vector3 moveDirection = Vector3.zero;
    public int jumpCount;
    public bool djump = true;

    [Header("Spells")] 
    public Transform spellSpawn;

    [Header("Fireball")] 
    public GameObject fireballPrefab;
    public float fireballSpeed = 20f;
    public float fireballExistanceTime = 2f;
    public float firaballCooldownTime = 1f;
    
    private Cooldown fireballCooldown;

    private void Start()
    {
        fireballCooldown = new Cooldown(firaballCooldownTime);
    }

    private void Update()
    {
        HandleMovement();
        HandleSpellCast();
    }

    private void HandleMovement()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            djump = true;
            jumpCount = 0;
        }

        if (jumpCount > 1)
        {
            djump = false;
        }

        if (djump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpCount += 1;
                moveDirection.y = jumpValue;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void HandleSpellCast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastFireBall();
        }
    }

    private void CastFireBall()
    {
        if (!fireballCooldown.IsInProgress()) {
            fireballCooldown.Start();
            
            GameObject fireball = Instantiate(fireballPrefab, spellSpawn.position, spellSpawn.rotation);
            fireball.GetComponent<Rigidbody>().velocity = fireball.transform.forward * fireballSpeed;
            Destroy(fireball, fireballExistanceTime);
        }
        else
        {
            Debug.Log("Fireball is on cooldown. Remaining " + fireballCooldown.GetRemainingValue());
        }
    }
}