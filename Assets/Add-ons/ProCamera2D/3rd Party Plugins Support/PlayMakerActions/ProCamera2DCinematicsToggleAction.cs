﻿#if PC2D_PLAYMAKER_SUPPORT

using Com.LuisPedroFonseca.ProCamera2D;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;
using UnityEngine;

[System.Obsolete("This action is obsolete; New ProCamera2D actions will be part of the PlayMaker Ecosystem for improved integration.")]
[Tooltip("Starts or stops a cinematic")]
public class ProCamera2DCinematicsToggleAction : FsmStateActionProCamera2DBase
{
	[RequiredField]
	[Tooltip("The gameObject that contains the ProCamera2DCinematics component")]
	public FsmGameObject Cinematics;

	public override void OnEnter()
	{
		var cinematics = Cinematics.Value.GetComponent<ProCamera2DCinematics>();

		if (cinematics == null)
			Debug.LogError("No Cinematics component found in the gameObject: " + Cinematics.Value.name);

		if (ProCamera2D.Instance != null && cinematics != null)
			cinematics.Toggle();

		Finish();
	}
}

#endif