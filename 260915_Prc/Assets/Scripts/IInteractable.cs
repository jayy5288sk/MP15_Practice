using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public GameObject GameObject { get; }

    public void Targeting();
    public void Untargeting();

    // 상호 작용을 당할 때 누군지 알아야 한다.
    public void Interact(IInteractor owner); // 누가 시도했는지.
}
