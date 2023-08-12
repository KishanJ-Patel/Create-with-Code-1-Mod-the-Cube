using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    [SerializeField] private float posZRange = 4f;
    [SerializeField] private float speedZAxis = 1f;

    [SerializeField] private Vector3 minScaleLimit = Vector3.one / 2f;
    [SerializeField] private Vector3 maxScaleLimit = Vector3.one * 1.5f;
    [SerializeField] private float scaleRate = 0.5f;

    [SerializeField] private float rotSpeed = 15f;
    
    private bool moveForward = false;
    private bool scaleUp = false;
    private Vector3 newScale;

    private int randNum;
    private float timeCount = 0;
    void Start()
    {
        randNum = Random.Range(0, 4);
    }

    void Update()
    {
        switch (randNum)
        {
            case 1:
                ChangeRotation();
                break;
            case 2: 
                MoveAlongZAxis(); 
                break;
            case 3:
                ChangeScale();
                break;
        }

        if (timeCount >= 1f)
        {
            ChangeColor();
            timeCount = 0f;
        }

        timeCount += Time.deltaTime;
    }

    private void ChangeRotation()
    {
        transform.Rotate(0.0f, rotSpeed * Time.deltaTime, 0.0f);
    }

    private void MoveAlongZAxis()
    {
        // Move the cube forward or backward
        if (!moveForward) transform.Translate(Vector3.back * speedZAxis * Time.deltaTime, Space.World);
        else transform.Translate(Vector3.forward * speedZAxis * Time.deltaTime, Space.World);

        // Check if the cube reached range limit
        if (transform.position.z <= -posZRange) moveForward = true;
        else if (transform.position.z >= posZRange) moveForward = false;
    }

    private void ChangeScale()
    {
        // Scale up or down the cube
        if (!scaleUp)
        {
            newScale = new Vector3(
                transform.localScale.x - (scaleRate * Time.deltaTime),
                transform.localScale.y - (scaleRate * Time.deltaTime),
                transform.localScale.z - (scaleRate * Time.deltaTime)
                );
            transform.localScale = newScale;
        }
        else
        {
            newScale = new Vector3(
                transform.localScale.x + (scaleRate * Time.deltaTime),
                transform.localScale.y + (scaleRate * Time.deltaTime),
                transform.localScale.z + (scaleRate * Time.deltaTime)
                );
            transform.localScale = newScale;
        }

        // Check if the cube reached scale limit
        if (transform.localScale.x <= minScaleLimit.x
                || transform.localScale.y <= minScaleLimit.y
                || transform.localScale.z <= minScaleLimit.z)
        {
            scaleUp = true;
        }
        else if (transform.localScale.x >= maxScaleLimit.x
                || transform.localScale.y >= maxScaleLimit.y
                || transform.localScale.z >= maxScaleLimit.z)
        {
            scaleUp = false;
        }
    }

    private void ChangeColor()
    {
        Material material = Renderer.material;

        material.color = new Color(Random.Range(0, 1f), 0.1f, 0.4f, 0.3f);
    }
}
