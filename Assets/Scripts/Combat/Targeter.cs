using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Targeter : NetworkBehaviour 
{

    private Targetable target;

    public Targetable GetTarget()
    {
        return target;
    }

    #region Server

    public override void OnStartServer()
    {
        GameOverHandler.ServerOnGameOver += ServerHandleGameOver;
    }

    public override void OnStopServer()
    {
        GameOverHandler.ServerOnGameOver -= ServerHandleGameOver;
    }

    [Command]
    public void CmdSetTarget(GameObject targetGameObject)
    {
        if(!targetGameObject.TryGetComponent<Targetable>(out Targetable newTarget)){return;}

        target = newTarget;
    }

    [Server]
    public void ClearTarget()
    {
        target = null;
    }

    private void ServerHandleGameOver()
    {
        ClearTarget();
    }

    #endregion

    #region Client

    #endregion
}
