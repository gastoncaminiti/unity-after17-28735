using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject cursorPoint;
    public GameObject CursorPoint { get => cursorPoint; set => cursorPoint = value; }

    [SerializeField] private float speed = 5f;
    public float Speed { get => speed; set => speed = value; }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveToPoint();
    }

    private void MoveToPoint()
    {
        Vector3 directionToMove = CursorPoint.transform.position - transform.position;
        if (directionToMove.magnitude > 1)
        {
            transform.LookAt(CursorPoint.transform.position);
            transform.position += Speed * directionToMove.normalized * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lifes"))
        {
            GameManager.addScore();
            Destroy(other.gameObject);
        }
    }
}
