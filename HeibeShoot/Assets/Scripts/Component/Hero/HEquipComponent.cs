using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Heibe.Shooter
{
	public enum EquipType
	{
		Head,
		LeftHand,
		RightHand,
		None
	}
	public class HEquipComponent : HBaseComponent
	{

		private Dictionary<int, HBaseEquip> mEquips;
		// Use this for initialization
		void Start()
		{
			mEquips = new Dictionary<int, HBaseEquip>();
			for (int i = 0; i < (int) EquipType.None; i++)
			{
				mEquips.Add(i,null);
			}
		}

		// Update is called once per frame
		void Update()
		{
			if (mEquips != null)
			{
				foreach (var equip in mEquips)
				{
					if (equip.Value == null)
						continue;

					equip.Value.IsUpdated = false;
				}
			}

			if (mEquips != null)
			{
				foreach (var equip in mEquips)
				{
					if (equip.Value == null)
						continue;

					if (equip.Value.IsActive)
					{
						equip.Value.OnUpdate(Time.deltaTime);
						equip.Value.IsUpdated = true;
					}
				}
			}
		}

		public void Equip(EquipType type, HBaseEquip equip)
		{
			int _type = (int) type;
			if(mEquips == null || !mEquips.ContainsKey(_type))
				return;

			if (mEquips[_type] != null)
			{
				mEquips[_type].OnDequip();
			}

			mEquips[_type] = equip;
			equip.OnEquip();
		}

		public void Equip(HBaseEquip equip)
		{
			if(equip.Types == null)
				return;

			for (int i = 0; i < equip.Types.Count; i++)
			{
				Equip(equip.Types[i],equip);
			}
		}
	}
}
