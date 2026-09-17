using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePlayerAnimHandler : MonoBehaviour
{
    [SerializeField] private string _moveXParam;
    [SerializeField] private string _moveZParam;

    private int _moveXAddress;
    private int _moveZAddress;

    private MazePlayerController _playerController;
}
