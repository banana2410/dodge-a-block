using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    public float _speed;
    private const float movementLimit = 4f;


    private Rigidbody2D _rb;


    private float _horizontalInput;
    private Vector2 _targetPos;


    void Start()
    {
        gameObject.transform.position = new Vector3(0, -2f, 0);
        _targetPos = gameObject.transform.position;
    }
    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        MovementCalculator();
    }
    private void FixedUpdate()
    {
        //Move rigidbody(player) to the calculated position in MovementCalculator!
        _rb.MovePosition(_targetPos);
    }

    private void MovementCalculator()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime * _speed;
        _targetPos = _rb.position + Vector2.right * _horizontalInput;
        _targetPos.x = Mathf.Clamp(_targetPos.x, -movementLimit, movementLimit);
    }
}
