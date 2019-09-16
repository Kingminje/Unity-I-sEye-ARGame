using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TInputcontroller : MonoBehaviour
{
    public GameObject cube;

    private void Update()
    {
        foreach (var touch in Input.touches)
        {
            Shoot(touch.position);
            if (Input.touchCount > 1 && touch.phase == TouchPhase.Began)
                AddCube();
        }
    }

    private void AddCube()
    {
        GameObject.Instantiate(cube, transform.position + transform.forward * 0.3f, transform.rotation);
    }

    private void Shoot(Vector2 screenPoint)
    {
        var ray = Camera.main.ScreenPointToRay(screenPoint);
        var hitinfo = new RaycastHit();
        if (Physics.Raycast(ray, out hitinfo))
        {
            hitinfo.rigidbody.AddForceAtPosition(ray.direction, hitinfo.point);
        }
    }
}