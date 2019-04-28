using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PiggyAI : MonoBehaviour {

    public float speed = 5f;
    
    private CurrencyPickup targetCurrency;

    private Transform target;
    
    void Update()
    {
        if(targetCurrency == null)
        {
            targetCurrency = CurrencySpawner.activeCurrency.OrderBy(x => (x.transform.position - transform.position).sqrMagnitude).First();
            // Another check to see if target currency actually found?
        }
        target = targetCurrency.transform;
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        Vector3 targetRotation = targetPosition - transform.position;
        if(targetRotation != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(targetRotation);
        }
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    
}
