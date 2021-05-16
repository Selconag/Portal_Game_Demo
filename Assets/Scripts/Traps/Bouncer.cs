using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bouncer : Trap
{
    TrapType m_Trap = TrapType.Bouncer;
    private void OnTriggerEnter(Collider other)
    {
        ActivateTrap(other);
    }
    public override void ActivateTrap(Collider other)
    {
        other.attachedRigidbody.AddRelativeForce(Vector3.forward * 500f);
        GameCondition(m_Trap);

    }
}
