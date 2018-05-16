using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Heibe.Shooter
{
	public abstract class HBaseGun : HBaseEquip
	{
		private enum GunState
		{
			Shooting,
			Reloading,
			Idle
		}
		protected override List<EquipType> GetTypes()
		{
			List<EquipType> types = new List<EquipType>();
			types.Add(EquipType.LeftHand);
			types.Add(EquipType.RightHand);
			return types;
		}

		protected int mBulletNum;

		private GunState mGunState = GunState.Idle;

		protected abstract BulletType GetBulletType();

		protected abstract float GetReloadTime();

		protected abstract float GetShootRate();

		protected abstract int GetMaxBulletNum();

		public abstract float GetShootForce();

		public virtual bool Shoot()
		{
			if (mGunState != GunState.Idle)
				return false;

			if (mBulletNum <= 0)
			{
				mBulletNum = 0;
				Reload();
				return false;
			}
			
			//Shoot
			mBulletNum--;
			mGunState = GunState.Shooting;
			Owner.StartCoroutine(_Shoot(GetShootRate()));
			return true;
		}

		public void Reload()
		{
			if(mGunState != GunState.Idle)
				return;
			
			//如果备弹足够
			mGunState = GunState.Reloading;
			Owner.StartCoroutine(_Reload(GetReloadTime(),GetMaxBulletNum() - mBulletNum));
		}

		private IEnumerator _Shoot(float waitTime)
		{
			yield return new WaitForSeconds(waitTime);
			mGunState = GunState.Idle;
		}

		private IEnumerator _Reload(float waitTime,int addNum)
		{
			yield return new WaitForSeconds(waitTime);
			mGunState = GunState.Idle;
			if (mBulletNum + addNum > GetMaxBulletNum())
			{
				addNum = GetMaxBulletNum() - mBulletNum;
			}

			mBulletNum += addNum;
			//减少库存
		}
	}
}
