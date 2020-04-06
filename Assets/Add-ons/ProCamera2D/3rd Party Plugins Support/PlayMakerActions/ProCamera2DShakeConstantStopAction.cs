#if PC2D_PLAYMAKER_SUPPORT

using Com.LuisPedroFonseca.ProCamera2D;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;
using UnityEngine;

[System.Obsolete("This action is obsolete; New ProCamera2D actions will be part of the PlayMaker Ecosystem for improved integration.")]
[Tooltip("Stops the current constant shake on the camera")]
public class ProCamera2DShakeConstantStopAction : FsmStateActionProCamera2DBase
{
	[RequiredField]
	[Tooltip("The camera with the ProCamera2D component, most probably the MainCamera")]
	public FsmGameObject MainCamera;

	public override void OnEnter()
	{
		var shake = MainCamera.Value.GetComponent<ProCamera2DShake>();

		if (shake == null)
			Debug.LogError("The ProCamera2D component needs to have the Shake plugin enabled.");

		if (ProCamera2D.Instance != null && shake != null)
			shake.StopConstantShaking();

		Finish();
	}
}

#endif