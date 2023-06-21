using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Opponent : MonoBehaviour
{
    public NavMeshAgent OpponentAgent;
    public GameObject Target;

    Vector3 OpponentStartPos;
    public GameObject speedBoosterIcon;

    // Start is called before the first frame update
    void Start()
    {
        OpponentAgent = GetComponent<NavMeshAgent>();
        OpponentStartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        speedBoosterIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        OpponentAgent.SetDestination(Target.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = OpponentStartPos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Speedboost"))
        {
            OpponentAgent.speed = OpponentAgent.speed + 3f;
            speedBoosterIcon.SetActive(true);
            StartCoroutine(SlowAfterAWhileCoroutine());
        }
    }
    private IEnumerator SlowAfterAWhileCoroutine() {
        yield return new WaitForSeconds(2.0f);
        OpponentAgent.speed = OpponentAgent.speed - 3f;
        speedBoosterIcon.SetActive(false);
    }

}
