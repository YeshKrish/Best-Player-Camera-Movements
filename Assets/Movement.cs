using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    private Rigidbody _rb;
    private float _moveSpeed = 10f;
    private float _jumpHeight = 10f;
    private float _hVelocity;
    private float _vVelocity;
    private float _velocity;

    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private GameObject _textMeshProUGUI;    
    [SerializeField]
    private GameObject _burstParticleEffect;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _hVelocity = Input.GetAxis("Horizontal");
        _vVelocity = Input.GetAxis("Vertical");
        //_velocity = _hVelocity * Time.deltaTime + _velocity * Time.deltaTime;

        _rb.velocity = new Vector3(_hVelocity * _moveSpeed, _rb.velocity.y, _vVelocity * _moveSpeed);
        if (Input.GetKey(KeyCode.Space))
        {
            _rb.velocity = new Vector3(_rb.velocity.x, _jumpHeight, _rb.velocity.z);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(Vector3.Distance(transform.position, _enemy.transform.position));
        if (Vector3.Distance(transform.position, _enemy.transform.position) < 7f)
        {
            _textMeshProUGUI.SetActive(true);   
        }
        else
        {
            _textMeshProUGUI.SetActive(false);
        }
   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            _burstParticleEffect.SetActive(true);
        }
    }
}
