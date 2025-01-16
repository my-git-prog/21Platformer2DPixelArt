using System.Collections;
using UnityEngine;

public class EffectDeath : MonoBehaviour
{
    [SerializeField] private float _deathTime = 1f;

    private void Start()
    {
        StartCoroutine(DestroyEffectObject());
    }

    private IEnumerator DestroyEffectObject()
    {
        var wait = new WaitForSeconds(_deathTime);

        yield return wait;

        Destroy(gameObject);
    }
}
