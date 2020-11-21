using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        if (Input.GetButton("Horizontal"))
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                x += 0.1f;
            }
            else
            {
                x -= 0.1f;
            }

            Vector3 position = new Vector3(x, y, z);
            transform.SetPositionAndRotation(position, Quaternion.Euler(new Vector3(0, y + 0.1f, 0)));
        }

        if (Input.GetButton("Vertical"))
        {
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                z += 0.1f;
            }
            else
            {
                z -= 0.1f;
            }

            Vector3 position = new Vector3(x, y, z);
            transform.SetPositionAndRotation(position, Quaternion.Euler(new Vector3(0, y + 0.1f, 0)));
        }
    }

}
