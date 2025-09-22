using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{

    [SerializeField] private Vector2 speedMovement;

    private Vector2 offset;

    private Material material;
    
    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }
    private void Update()
    {
        offset = speedMovement * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
