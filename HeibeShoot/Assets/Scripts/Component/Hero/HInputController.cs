using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Heibe.Shooter
{
	public class HInputController : HBaseComponent
	{
		public float GetAxis(string axisName)
		{
			return Input.GetAxis(axisName);
		}
	}
}
