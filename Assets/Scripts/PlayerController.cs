using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = Input.GetAxis("Vertical");

        Vector2 newPos = transform.position;
        newPos.x += xMovement * Time.deltaTime * speed;
        newPos.y += yMovement * Time.deltaTime * speed;

        transform.position = newPos;
    }
}
