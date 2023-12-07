using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace War
{
    public class Bullet : Fighter
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.name);
            Hit(new HitResult(this, other.GetComponent<IReceiveHit>(), other.ClosestPointOnBounds(this.transform.position), HitResult.Result.Success));
        }
    }
}