using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    [SerializeField] private float posZRange = 4f;
    [SerializeField] private float speedZAxis = 1f;

    private bool moveForward = false;

    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;
        
        Material material = Renderer.material;
        
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }
    
    void Update()
    {
        transform.Rotate(10.0f * Time.deltaTime, 0.0f, 0.0f);

        if (!moveForward ) transform.Translate(Vector3.back * speedZAxis * Time.deltaTime, Space.World);
        else transform.Translate(Vector3.forward * speedZAxis * Time.deltaTime, Space.World);

        if (transform.position.z <= -posZRange) moveForward = true;
        else if (transform.position.z >= posZRange) moveForward = false;

    }
}
