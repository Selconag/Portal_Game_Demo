using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Killer : Trap
{
    TrapType m_Trap = TrapType.Killer;
    private void OnTriggerEnter(Collider other)
    {
        ActivateTrap(other);
    }
    public override void ActivateTrap(Collider other)
    {
        Destroy(other.gameObject);
        GameCondition(m_Trap);
    }
}
