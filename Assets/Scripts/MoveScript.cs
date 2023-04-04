using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveScript : MonoBehaviour
{
    [SerializeField] Transform[] points;
    [SerializeField] Transform startPoint;

    [SerializeField] float speed;


    private void Start()
    {
        transform.position = Vector3.zero;
   
    }
    private void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }   
       


    }
}
