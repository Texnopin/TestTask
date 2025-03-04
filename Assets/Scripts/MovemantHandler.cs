using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovemantHandler : IDisposable
{
    private IInput _input;
    private Player _player;
    public MovemantHandler(IInput input, Player player)
    {
        _input = input;
        _player = player;

        _input.OnMoveInput += Move;
        _player = player;
    }
    public void Dispose()
    {
        _input.OnMoveInput -= Move;
    }

    private void Move(Vector3 direction)
    {
        _player.Move(direction);
    }

}
