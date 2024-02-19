using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathingComponent : MonoBehaviour
{

    [SerializeField] private float _moveSpeed;

    // List of points to follow
    [SerializeField] private Transform[] _path;

    [SerializeField] private float _minDistance;

    [SerializeField] private float _timeToWait;

    private int rdmNum_;
    private int lastRdmNum_;


    // Start is called before the first frame update
    void Start()
    {
        rdmNum_ = Random.Range(0, _path.Length);
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
            while (transform.position != _path[rdmNum_].position)
            {
                transform.position = Vector3.MoveTowards(transform.position, _path[rdmNum_].position, Time.deltaTime * _moveSpeed);
                yield return null;
            }
            yield return new WaitForSeconds(_timeToWait);

            generateNextPoint() ;
        }
    }
    private void generateNextPoint()
    {
        int aux = rdmNum_;
        do
        {
            rdmNum_ = Random.Range(0, _path.Length);
        } while (rdmNum_ == lastRdmNum_ || rdmNum_ == aux);

        lastRdmNum_ = aux;
    }
}
