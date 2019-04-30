using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PiggyAI : MonoBehaviour {

    private PiggyBank pig;
    
    private CurrencyPickup targetCurrency;

    private Transform target;

    private void Start()
    {
        pig = GetComponent<PiggyBank>();
    }

    void Update()
    {
        if(targetCurrency == null)
        {
            if(CurrencySpawner.activeCurrency.Count > 0)
            {
                targetCurrency = CurrencySpawner.activeCurrency.OrderBy(x => (x.transform.position - transform.position).sqrMagnitude).First();
            }
        }

        Vector3 targetPosition = transform.position;
        if(targetCurrency != null)
        {
            target = targetCurrency.transform;
            targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        }

        Vector3 targetRotation = targetPosition - transform.position;
        if(targetRotation != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(targetRotation);
        }
        transform.position += transform.forward * pig.speed * Time.deltaTime;
    }
    
}
