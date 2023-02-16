using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Material mat;
    [SerializeField] private Transform pos1, pos2;
    [SerializeField] private float speed;

    private string state = "IDLE";
    private Rigidbody rb;
    private Material defaultMat;

    private void Awake()
    {
        transform.position = pos1.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        defaultMat = gameObject.GetComponent<MeshRenderer>().material;
        StartCoroutine(ChangeState());
    }

    IEnumerator ChangeState()
    {
        yield return new WaitForSeconds(2f);
        if (state == "IDLE")
        {
            gameObject.GetComponent<MeshRenderer>().material = mat;
            rb.velocity = new Vector2(speed, 0);
            state = "DANGER";
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(state == "DANGER")
        {
            if(transform.position.x < pos1.position.x || transform.position.x > pos2.position.x)
            {
                gameObject.GetComponent<MeshRenderer>().material = defaultMat;
                rb.velocity = Vector2.zero;
                state = "IDLE";
                speed = -speed;
                StartCoroutine(ChangeState());
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameManager.instance.Ending(false);
    }

}
