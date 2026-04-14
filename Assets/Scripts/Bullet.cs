using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string target;
    public int damage = 1;

    void Start()
    {
        StartCoroutine(Shoot());
    }

    void Update()
    {
        
    }

    public IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(GetComponent<MeshRenderer>());
        Destroy(GetComponent<Collider>());
        yield return new WaitForSeconds(2.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(target)) {
            other.gameObject.GetComponent<Damagable>().TakeDamage(damage);            
        }
    }
}
