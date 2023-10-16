using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace War
{
    public class Bubble : Fighter
    {
        public float speed;
        // Update is called once per frame
        private void FixedUpdate()
        {
            transform.position += new Vector3(0, 0, speed * Time.fixedDeltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log(collision.collider.name);
            Hit(new HitResult(this, collision.collider.GetComponent<Fighter>(), collision.collider.ClosestPointOnBounds(this.transform.position), HitResult.Result.Success));
        }

    }
}