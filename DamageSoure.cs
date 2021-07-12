using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSoure : MonoBehaviour
{
    private bool _isCausingDamage = false;

    public float DamageRepeatRate = 0.1f;

    public int DamageAmount = 1;

    public bool Repeating = true;
    private void OnTriggerEnter(Collider other)
    {
        _isCausingDamage = true;

        CharacterCtrl player = other.gameObject.GetComponent<CharacterCtrl>();

        if (player != null)
        {
            if (Repeating)
            {
                StartCoroutine(TakeDamage(player, DamageRepeatRate));
            }
            else
            {
                player.TakeDamage(DamageAmount);
            }
        }
    }

    IEnumerator TakeDamage(CharacterCtrl player, float repeatRate)
    {
        while(_isCausingDamage)
        {
            player.TakeDamage(DamageAmount);
            TakeDamage(player, repeatRate);

            if (player.IsDead)
                _isCausingDamage = false;

            yield return new WaitForSeconds(repeatRate);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CharacterCtrl player = other.gameObject.GetComponent<CharacterCtrl>();
        if(player != null)
        {
            _isCausingDamage = false;
        }
    }
}
