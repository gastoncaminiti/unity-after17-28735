using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAgent : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject cursorPoint;

    private NavMeshAgent playerAgent;

    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        CursorUpdate();
        playerAgent.destination = cursorPoint.transform.position;
    }

    void CursorUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cursorPoint.transform.position = GetPositionTo(Input.mousePosition);
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
