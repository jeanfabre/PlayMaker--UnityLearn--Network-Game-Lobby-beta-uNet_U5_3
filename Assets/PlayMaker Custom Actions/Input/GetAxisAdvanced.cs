// (c) Copyright HutongGames, LLC 2010-2016. All rights reserved.
/*--- __ECO__ __PLAYMAKER__ __ACTION__
EcoMetaStart
{
"script dependancies":[
						"Assets/PlayMaker Custom Actions/__Internal/FsmStateActionAdvanced.cs"
					]
}
EcoMetaEnd
---*/
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Math)]
	[Tooltip("Gets the value of the specified Input Axis and stores it in a Float Variable. See Unity Input Manager docs.")]
	public class GetAxisAdvanced : FsmStateActionAdvanced
	{
		[RequiredField]
		[Tooltip("The name of the axis. Set in the Unity Input Manager.")]
		public FsmString axisName;

		[Tooltip("Axis values are in the range -1 to 1. Use the multiplier to set a larger range.")]
		public FsmFloat multiplier;

		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the result in a float variable.")]
		public FsmFloat store;


		public override void Reset()
		{
			base.Reset();
			
			axisName = "";
			multiplier = 1.0f;
			store = null;
		}

		public override void OnEnter()
		{
			OnActionUpdate ();
			
			if (!everyFrame)
			{
			    Finish();
			}
		}

		public override void OnActionUpdate()
		{
			if (FsmString.IsNullOrEmpty(axisName)) return;

			var axisValue = Input.GetAxis(axisName.Value);

			// if variable set to none, assume multiplier of 1
			if (!multiplier.IsNone)
			{
				axisValue *= multiplier.Value;
			}

			store.Value = axisValue;
		}
	}
}
