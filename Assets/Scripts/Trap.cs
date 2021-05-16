using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Classes for traps and other interactable objects
public enum TrapType { Killer, Portal, Bouncer}
public abstract class Trap : MonoBehaviour
{
    public abstract void ActivateTrap(Collider other);
    

    GameManager m_G;
    private void Start()
    {
        m_G = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void GameCondition(TrapType Trap)
    {
        switch (Trap)
        {
            case TrapType.Bouncer:
                //Push the Ball
                break;
            case TrapType.Killer:
                //Set the game as losed
                m_G.Game_Resolution(false);
                break;
            case TrapType.Portal:
                //Set the game as winned
                m_G.Game_Resolution(true);
                break;
        }
    }
}

public interface IChangeColor
{
    //Destroy this game object
    IEnumerator ActivateWall(Collider other);
}
