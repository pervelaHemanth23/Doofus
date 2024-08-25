using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public DoofusDiary dataManager;

    [SerializeField] float speed = 5;

    private void Start()
    {
        // speed = dataManager.data.player_data.speed;
    }

    private void Update()
    {
        movePlayer();
    }

    public void movePlayer()
    {
        float xVal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float zVal = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(xVal, 0, zVal);
    }
}
