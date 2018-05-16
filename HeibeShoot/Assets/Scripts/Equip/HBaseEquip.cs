using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Heibe.Shooter
{
	public abstract class HBaseEquip
	{
		protected bool mIsActive;
		public bool IsActive
		{
			get { return mIsActive; }
		}

		protected List<EquipType> mTypes;
		public List<EquipType> Types
		{
			get { return mTypes; }
			set { mTypes = value; }
		}

		protected bool mIsUpdated;
		public bool IsUpdated
		{
			get { return mIsUpdated; }
			set { mIsUpdated = value; }
		}

		protected HEquipComponent mOwner;
		public HEquipComponent Owner
		{
			get { return mOwner; }
			set { mOwner = value; }
		}


		public virtual void OnEquip()
		{
			mIsActive = true;
		}

		public virtual void OnDequip()
		{
			mIsActive = false;
		}

		public void SetEquipTypes()
		{
			mTypes = GetTypes();
		}

		protected abstract List<EquipType> GetTypes();

		public virtual void OnUpdate(float deltaTime)
		{
		}
	}
}
