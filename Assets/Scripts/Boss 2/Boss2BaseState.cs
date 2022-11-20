using UnityEngine;

public abstract class Boss2BaseState{
    public abstract void EnterState(Boss2StateManager boss);

    public abstract void UpdateState(Boss2StateManager boss);

}