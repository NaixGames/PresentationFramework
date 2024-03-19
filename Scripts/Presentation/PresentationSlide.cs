using Godot;
using System;
using System.Collections.Generic;
using CoreCode.Scripts;

namespace PresentationFramework{
	public partial class PresentationSlide : Node, IControlableByInput
	{
		private PresentationManager mPresentationManager;
		private InputReaderAbstract mInput;
		private List<BulletPoint> mBulletPoints = new List<BulletPoint>();
		private int mBulletPointIndex = 0;

		// --------------------------------------------------------------------

		// Called when the node enters the scene tree for the first time.
		public void Initiate(PresentationManager presentationManager)
		{
			foreach (Node node in this.GetChildren(false)){
				if (node is BulletPoint){
					BulletPoint bulletPoint = (BulletPoint) node;
					mBulletPoints.Add(bulletPoint);
				}
			}

			mInput = InputManager.Instance.GiveInputByPlayerChannel(this, 0);

			mPresentationManager = presentationManager;
		}

		// --------------------------------------------------------------------

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
			if (mInput.IsButtonJustPressedInput("Next")){
				if (mBulletPointIndex == -1){
					mBulletPointIndex++;
					return;
				}
				if (mBulletPointIndex<mBulletPoints.Count){
					mBulletPoints[mBulletPointIndex].ShowBulletPoint();
					mBulletPointIndex ++;
					return;
				}
				mPresentationManager.LoadNextSlide();
			}
			if (mInput.IsButtonJustPressedInput("Back")){
				if (mBulletPointIndex == mBulletPoints.Count){
					mBulletPointIndex--;
					return;
				}
				if (mBulletPointIndex>-1){
					mBulletPoints[mBulletPointIndex].HideBulletPoint();
					mBulletPointIndex --;
					return;
				}
				mPresentationManager.LoadPreviousSlide();
			}
		}

		// --------------------------------------------------------------------

		//Controlable by input abstract interface implementation

		public InputReaderAbstract ReturnInputReader(){
			return mInput;
		}

		public void ClearInputReader(){
			return;
		}

		public void RecieveInputReader(InputReaderAbstract inputReaderPath){
			mInput = inputReaderPath;
		}

		// --------------------------------------------------------------------

	}
}