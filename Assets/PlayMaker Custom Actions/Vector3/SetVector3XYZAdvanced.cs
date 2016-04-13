// (c) Copyright HutongGames, LLC 2010-2016. All rights reserved.
/*--- __ECO__ __PLAYMAKER__ __ACTION__ 
EcoMetaStart
{
"script dependancies":[
						"Assets/PlayMaker Custom Actions/__internal/PlayMakerActionsUtils.cs"
					],
"version":"1.1.0"
}
EcoMetaEnd

*/

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Vector3)]
	[Tooltip("Sets the XYZ channels of a Vector3 Variable. To leave any channel unchanged, set variable to 'None'.")]
	public class SetVector3XYZAdvanced : FsmStateAction
	{
		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmVector3 vector3Variable;
		[UIHint(UIHint.Variable)]
		public FsmVector3 vector3Value;
		public FsmFloat x;
		public FsmFloat y;
		public FsmFloat z;

		public bool everyFrame;

		public PlayMakerActionsUtils.EveryFrameUpdateSelector updateType;

		public override void Reset()
		{
			vector3Variable = null;
			vector3Value = null;
			x = new FsmFloat{ UseVariable = true};
			y = new FsmFloat{ UseVariable = true};
			z = new FsmFloat{ UseVariable = true};
			everyFrame = false;
			updateType = PlayMakerActionsUtils.EveryFrameUpdateSelector.OnUpdate;
		}
		
		public override void Awake()
		{
			if (updateType == PlayMakerActionsUtils.EveryFrameUpdateSelector.OnFixedUpdate)
			{
				Fsm.HandleFixedUpdate = true;
			}
		}
		
		
		public override void OnUpdate()
		{
			if (updateType == PlayMakerActionsUtils.EveryFrameUpdateSelector.OnUpdate)
			{
				DoSetVector3XYZ();
			}
			
			if (!everyFrame)
			{
				Finish();
			}
		}
		
		public override void OnLateUpdate()
		{
			if (updateType == PlayMakerActionsUtils.EveryFrameUpdateSelector.OnLateUpdate)
			{
				DoSetVector3XYZ();
			}
			
			if (!everyFrame)
			{
				Finish();
			}
		}
		
		public override void OnFixedUpdate()
		{
			if (updateType == PlayMakerActionsUtils.EveryFrameUpdateSelector.OnFixedUpdate)
			{
				DoSetVector3XYZ();
			}
			
			if (!everyFrame)
			{
				Finish();
			}
		}
		
		void DoSetVector3XYZ()
		{
			if (vector3Variable == null) return;

			Vector3 newVector3 = vector3Variable.Value;

			if (!vector3Value.IsNone) newVector3 = vector3Value.Value;
			if (!x.IsNone) newVector3.x = x.Value;
			if (!y.IsNone) newVector3.y = y.Value;
			if (!z.IsNone) newVector3.z = z.Value;

			vector3Variable.Value = newVector3;
		}
	}
}

