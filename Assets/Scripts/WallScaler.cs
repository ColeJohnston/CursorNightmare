using UnityEngine;

public class WallScaler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.localScale = new Vector3(transform.localScale.x, Camera.main.orthographicSize * 2, transform.localScale.z);
    }
}
