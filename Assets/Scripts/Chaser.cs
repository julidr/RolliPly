using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(CharacterController))]

public class Chaser : MonoBehaviour
{

    public float speed = 20.0f;
    public float minDist = 1f;
    public GameObject target;

    // Use this for initialization
    void Start()
    {
        // if no target specified, assume the player
        if (target == null)
        {

            if (GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindWithTag("Player");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        // face the target
        Transform targetTransform = target.GetComponent<Transform>();
        transform.LookAt(targetTransform);

        //get the distance between the chaser and the target
        float distance = Vector3.Distance(transform.position, targetTransform.position);

        //so long as the chaser is farther away than the minimum distance, move towards it at rate speed.
        if (distance > minDist)
        {
            transform.position += transform.forward * target.GetComponent<Rigidbody>().velocity.magnitude * Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(target.GetComponent<Rigidbody>().velocity);
        gameObject.GetComponent<Rigidbody>().maxAngularVelocity = target.GetComponent<Rigidbody>().maxAngularVelocity;
    }

    // Set the target of the chaser
    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }

}
