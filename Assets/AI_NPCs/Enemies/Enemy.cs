using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 roamPosition;
    [SerializeField] private float moveSpeed = 5f;

    private void Start() 
    {
        startPosition = transform.position;
        roamPosition = getRoamingPosition();    
    }

    private void Update() 
    {
        transform.position = Vector3.MoveTowards(transform.position, roamPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, roamPosition) < 1f) //roam position reached
        {
            roamPosition = getRoamingPosition();
        }
    }

    private Vector3 getRoamingPosition()
    {
        return startPosition + new Vector3(UnityEngine.Random.Range(-1f,1f), UnityEngine.Random.Range(-1f,1f)).normalized * Random.Range(1f, 5f);
    }


}
