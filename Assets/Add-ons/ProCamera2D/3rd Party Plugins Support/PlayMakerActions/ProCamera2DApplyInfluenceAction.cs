#if PC2D_PLAYMAKER_SUPPORT

using Com.LuisPedroFonseca.ProCamera2D;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[System.Obsolete("This action is obsolete; New ProCamera2D actions will be part of the PlayMaker Ecosystem for improved integration.")]
[Tooltip("Apply the given influence to the camera")]
public class ProCamera2DApplyInfluenceAction : FsmStateActionProCamera2DBase
{
	[Tooltip("The vector representing the influence to be applied")]
	public FsmVector2 Influence;

	public override void OnUpdate()
	{
		if (ProCamera2D.Instance != null)
			ProCamera2D.Instance.ApplyInfluence(Influence.Value);
	}
}

#endif