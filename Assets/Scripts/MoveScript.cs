using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveScript : MonoBehaviour
{
    private List<Transform> points = new List<Transform>();
    private GameObject[] GO; 

    [SerializeField] float speed;

    private int nextPoint = 0;
    private bool isForward = true;
    private void Start()
    {
        
        GO = GameObject.FindGameObjectsWithTag("Points");
        for(int i  = GO.Length - 1; i >= 0; i--)
        {
            points.Add(GO[i].transform);
        }
        transform.position = points[0].position;
    }
    private void Update()
    {
        if (points.IndexOf(points[nextPoint]) == 0)
            isForward = true;
        else if (points.IndexOf(points[nextPoint]) == points.Count - 1)
            isForward = false;

        if (Vector3.Distance(points[nextPoint].position,transform.position) > 0.1)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[nextPoint].position, speed * Time.deltaTime);
        }    
        else if (Vector3.Distance(points[nextPoint].position, transform.position) <= 0.1)
        {
            if(isForward) 
                nextPoint++;
            else 
                nextPoint--;
            transform.position = Vector3.MoveTowards(transform.position, points[nextPoint].position, speed * Time.deltaTime);
        }
        

    }
}
