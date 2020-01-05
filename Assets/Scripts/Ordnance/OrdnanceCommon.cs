using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdnanceCommon : MonoBehaviour
{
    /// <summary>
    /// Instantiates the specified Explosion prefab at the sender's coordinates and destroys the sender.
    /// </summary>
    /// <param name="sender">GameObject that is calling this method.</param>
    /// <param name="owner">GameObject that's exploding.</param>
    /// <param name="explosionPrefab">Explosion prefab to instantiate.</param>
    public static void Explode(GameObject sender, GameObject owner, Explosion explosionPrefab)
    {
        Explosion explosion = Instantiate(explosionPrefab, sender.transform.position, sender.transform.rotation);
        explosion.owner = owner;

        Destroy(sender);
    }
}
