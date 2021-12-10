using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMSystem 
{
    public PlayerInput playerInput { get; private set; }
    private Dictionary<StateID, FSMState> dicStates;
    public FSMState state;
    public  FSMSystem(PlayerInput input)
    {
        playerInput = input;
        //添加状态
    }

    public void Update()
    {
        state.OnUpdateState();
    }

    public void ChangeState(StateID id)
    {
        state.OnExitState();
        state = dicStates[id];
        state.OnEnterState();
    }
}
