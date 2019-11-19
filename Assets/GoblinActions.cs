using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinActions : MonoBehaviour {
    public Transform[] PatrolPoints;

    public void StartPatrol()
    {
        gameObject.Send<IMover>(_ => _.SetDestination(PatrolPoints[1].position));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
