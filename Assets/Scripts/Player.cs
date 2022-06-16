using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private ParticleSystem _death;
    [SerializeField] private ParticleSystem _finish;
    [SerializeField] private GameObject _startPosition;
    private NavMeshAgent _navMeshAgent;
    private GameObject _this;
    public bool Shield { get; set; } = false;

    void Start()
    {
        _this = gameObject;
 
        Debug.LogError(_startPosition);
        StartCoroutine(StartPlay());
    }
    IEnumerator StartPlay()
    {
        yield return new WaitForSeconds(2f);
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.SetDestination(new Vector3(85, 0, 85));
    }

    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out DeathZone death))
        {
            if (!Shield)
            {
                StartCoroutine(Die());
            }
            
        }
        else if (collision.TryGetComponent(out FinishZone finish))
        {
            StartCoroutine(Finish());
        }
    }


    IEnumerator Die()
    {
        MeshRenderer meshRendererPlayer = _this.GetComponent<MeshRenderer>();
        _navMeshAgent.enabled = false;
        var particle = Instantiate(_death, transform.position, Quaternion.Euler(-90, 0, 0));
        particle.Play();
        meshRendererPlayer.enabled = false;
        yield return new WaitForSeconds(2f);
        _this.transform.position = _startPosition.transform.position;
        meshRendererPlayer.enabled = true;
        Destroy(particle);
        _navMeshAgent.enabled = true;
        StartCoroutine(StartPlay());
    }
    IEnumerator Finish()
    {
        MeshRenderer meshRendererPlayer = _this.GetComponent<MeshRenderer>();
        _navMeshAgent.Stop();
        var particle = Instantiate(_finish, transform.position, Quaternion.Euler(-90, 0, 0));
        particle.Play();

        yield return new WaitForSeconds(2f);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        meshRendererPlayer.enabled = true;
    }

}
