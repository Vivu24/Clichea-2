using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{

    [SerializeField] private float moveSpeed_;

    // List of points to follow
    [SerializeField] private Transform[] path_;

    [SerializeField] private float minDistance_;

    [SerializeField] private float timeToWait_;

    private int rdmNum_;
    private int lastRdmNum_;


    // Start is called before the first frame update
    void Start()
    {
        rdmNum_ = Random.Range(0, path_.Length);
        StartCoroutine(followPath());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator followPath()
    {
        while (true)
        {
            while (transform.position != path_[rdmNum_].position)
            {
                transform.position = Vector3.MoveTowards(transform.position, path_[rdmNum_].position, Time.deltaTime * moveSpeed_);
                yield return null;
            }
            yield return new WaitForSeconds(timeToWait_);

            generateNextPoint() ;
        }
    }
    private void generateNextPoint()
    {
        int aux = rdmNum_;
        do
        {
            rdmNum_ = Random.Range(0, path_.Length);
        } while (rdmNum_ == lastRdmNum_ || rdmNum_ == aux);

        lastRdmNum_ = aux;
    }
}
