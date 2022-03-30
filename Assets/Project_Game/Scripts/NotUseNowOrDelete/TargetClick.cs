using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetClick : MonoBehaviour
{
    public Transform objecthit;
    public bool isClick = false;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isClick = true;
            Debug.Log("Click");
            CastRay();
        }
    }

    void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if (hit)
        {
            objecthit = hit.transform; 
            Debug.Log($"{hit.transform.gameObject.name}");
            isClick = false;
        }
    }
}
