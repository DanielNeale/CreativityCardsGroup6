using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    Transform fence;
    Transform pivot;

    void Start()
    {
        fence = transform.GetChild(0).transform;
        pivot = transform;
    }

    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        Ray pointing = Camera.main.ScreenPointToRay(mousePos);

        RaycastHit hit;

        if (Physics.Raycast(pointing, out hit) && hit.transform.CompareTag("Gate"))
        {
            if (pivot.rotation.y > 0.98)
            {
                pivot.Rotate(new Vector3(0, -1, 0));
            }

            if (Input.GetMouseButtonDown(0))
            {
                for(float i = 3.0f; i > 0; i -= Time.deltaTime)
                {
                    if (pivot.rotation.y < 0.75)
                    {
                        pivot.Rotate(new Vector3(0, -1, 0));
                    }

                    if (i <= 0.1)
                    {
                        Debug.Log("new scene");
                    }
                }
            }
        }

        else
        {
            if (pivot.rotation.y < 1)
            {
                pivot.Rotate(new Vector3(0, 1, 0));
            }
        }
    }
}
