using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelayScript : MonoBehaviour
{
    private List<Transform> runners = new List<Transform>();
    private GameObject[] GO;
    [SerializeField] Transform finish;

    [SerializeField] float speed;
    [SerializeField] float passDistance;

    public int nextRunner;
    public int currentRunner;
    private void Start()
    {

        GO = GameObject.FindGameObjectsWithTag("Runner");
        for (int i = GO.Length - 1; i >= 0; i--)
        {
            runners.Add(GO[i].transform);
        }
        currentRunner = 0;
        nextRunner = 1;
    }
    private void Update()
    {
        runners[currentRunner].LookAt(runners[nextRunner]);
        runners[currentRunner].position = Vector3.MoveTowards(runners[currentRunner].position, runners[nextRunner].position, speed * Time.deltaTime);
        if(Vector3.Distance(runners[currentRunner].position, runners[nextRunner].position) <= passDistance)
        {
            currentRunner++;
            nextRunner++;
        }
        

    }
}
