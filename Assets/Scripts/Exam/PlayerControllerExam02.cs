using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExam02 : MonoBehaviour
{
    public float speed;
    public float zRange = 10;
    public GameObject projectilePrefab;

    private float verticalInput;
    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = moveAction.ReadValue<Vector2>().y;

        transform.Translate(verticalInput * speed * Time.deltaTime * Vector3.left);

        // [5] keep the player inbounds
        // if (transform.position.x < -10)
        // {
        //     transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        // }

        // [7] keep the player inbounds using xRange variable
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange );
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3( transform.position.x, transform.position.y, zRange );
        }

        // [12] check if the player is shooting
        if (shootAction.triggered)
        {
            // [13] spawn a projectile
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
