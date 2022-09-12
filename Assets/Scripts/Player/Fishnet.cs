using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fishnet : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private ParticleSystem _particleSystem;

    [SerializeField] private float _stopDistance;
    [SerializeField] private float _speed;
    [SerializeField] private float _effectTime;

    private SphereCollider _sphereCollider;

    public int Number;

    private void Start()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _particleSystem.Pause();
    }

    private void Update()
    {
        transform.LookAt(_target);

        if(Vector3.Distance(transform.position,_target.position) > _stopDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position,_target.position,_speed * Time.deltaTime);
        } 
    }

    public void StartEffect()
    {
        _particleSystem.Play();
    }

    private IEnumerator PLayEffect()
    {
        float time = 0;

        _particleSystem.Play();

        while(time >= _effectTime)
        {
            time += Time.deltaTime;
        }
        _particleSystem.Stop();

        yield break;
    }
}
