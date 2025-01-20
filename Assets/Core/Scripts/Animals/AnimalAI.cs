using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[Serializable]
public class AnimalAI : IDisposable
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _wonderPeriod;

    private CancellationTokenSource _cancellationTokenSource = new ();

    public bool IsMoving => _agent.velocity != Vector3.zero;
    
    public void Initialize(AnimalStats stats)
    {
        _agent.speed = stats.speed;
        
        _cancellationTokenSource = _cancellationTokenSource.Rebirth();
        Wonder(_cancellationTokenSource.Token);
    }

    private async void Wonder(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            _agent.SetDestination(GetRandomDestination());
            await Task.Delay((int)((_wonderPeriod + Random.Range(0, _wonderPeriod/10)) * 1000));
        }
    }

    private Vector3 GetRandomDestination()
    {
        Vector3 randomVector = new Vector3(
            Random.Range(-10f, 10f),
            0,
            Random.Range(-10f, 10f)
        );
        return _agent.transform.position + randomVector;
    }

    public void Dispose()
    {
        _cancellationTokenSource?.Kill();
    }
}