using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Heibe.Shooter
{
	public class HAimComponent : HBaseComponent
	{
		private Camera mAimCamera;

		private Vector3 mNormalPosition;

		private Quaternion mNormalRotation;

		private float mNormalFov;

		private int mMagnify;//放大倍数
		public int Magnify
		{
			get { return mMagnify; }
			set { mMagnify = value; }
		}
		
		private float mMagnifySpeed = 50f;//放大速度  

		public float MagnifySpeed
		{
			get { return mMagnifySpeed; }
			set { mMagnifySpeed = value; }
		}
		private float mShrinkSpeed = 50f;//缩小速度  
		public float ShrinkSpeed
		{
			get { return mShrinkSpeed; }
			set { mShrinkSpeed = value; }
		}

		private bool mIsAiming;
		public bool IsAiming
		{
			get { return mIsAiming; }
			set { mIsAiming = value; }
		}

		// Use this for initialization
		void Start()
		{
			
			HCameraComponent hcamera = Component<HCameraComponent>();
			if (hcamera != null)
				mAimCamera = hcamera.EyeCamera;
			else
				mAimCamera = Camera.main;
		}

		// Update is called once per frame
		void Update()
		{
			if (IsAiming)
			{
				MagnifyView();
			}
			else
			{
				ShrinkView();
			}
		}
		
		/// <summary>  
		/// 放大视野  
		/// </summary>  
		private void MagnifyView()//放大视野就是，减小FOV的值  
		{  
			//如果现在FOV-下一帧的视野值，还大于原有视野值的一半，就继续减少视野值，放大视野  
			if ((mAimCamera.fieldOfView - Time.deltaTime * mMagnifySpeed) >= (mNormalFov / mMagnify))  
			{  
				mAimCamera.fieldOfView -= Time.deltaTime * mMagnifySpeed;  
			}  
			else//否则保持视野值到最小值  
			{  
				mAimCamera.fieldOfView = mNormalFov / mMagnify;   
			}  
		}  
  
		/// <summary>  
		/// 缩小视野  
		/// </summary>  
		private void ShrinkView()  
		{  
			//如果现在FOV+下一帧的视野值，还小于原有视野值的一半，就继续增减视野值，缩小视野  
			if ((mAimCamera.fieldOfView + Time.deltaTime * mShrinkSpeed) <= mNormalFov)  
			{  
				mAimCamera.fieldOfView += Time.deltaTime * mShrinkSpeed;  
			}  
			else//否则保持视野值到初始垂直视野值  
			{  
				mAimCamera.fieldOfView = mNormalFov;  
			}  
		}  
	}
}
