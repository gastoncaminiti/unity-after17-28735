using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMousePlane : MonoBehaviour
{
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (player != null)
        {
            Debug.Log(" PLANO CLICK ");
            Debug.Log(Input.mousePosition);
            Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            player.CursorPoint.transform.position =  GetPositionTo(Input.mousePosition);
        }

    }

    private Vector3 GetPositionTo(Vector3 newPositon)
    {
        RaycastHit hit;
        Ray rayPosition = Camera.main.ScreenPointToRay(newPositon);
        if (Physics.Raycast(rayPosition, out hit))
        {
            return hit.point;
        }
        return Vector3.zero;
        
    }
}
