using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float acceleration = 10;
    public float speedMultiplier = 5f;
    public float maxSpeed = 50f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.currentGameState == GameManager.GameState.Playing)
        {
            // Move the camera to the right at a constant speed
            transform.position += new Vector3(Time.deltaTime * speedMultiplier, 0, 0);

            if (speedMultiplier < maxSpeed)
            {
                speedMultiplier += (acceleration * .02f) * Time.deltaTime; // Gradually increase the speed
            }
        }
    }
}
