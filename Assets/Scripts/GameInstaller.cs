using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{

    public override void InstallBindings()
    {
        GameObject playerObject = GameObject.Find("Player");
        Player player = playerObject.GetComponent<Player>();

        Container.Bind<Player>().FromInstance(player).AsSingle();

        MobileInput mobileInput = new MobileInput();

        Container.Bind<IInput>().FromInstance(mobileInput).AsSingle();

        Container.Bind<MovemantHandler>().AsSingle().WithArguments(
            Container.Resolve<IInput>(),
            Container.Resolve<Player>()
        );

        StartCoroutine(UpdateLoop(mobileInput));
    }

    private IEnumerator UpdateLoop(MobileInput input)
    {
        while (true)
        {
            input.Update();
            yield return null;
        }
    }

}
