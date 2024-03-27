using Godot;
using System;

namespace PresentationFramework{
	public partial class PresentationManager : Node
	{
		[Export] private int mInitialSlide;
		[Export] private string[] mSlidesPaths;
		private int mSlideIndex=0;
		private Node mActualSlide;

		// --------------------------------------------------------------------

		public override void _Ready()
		{
			if (mInitialSlide >= mSlidesPaths.Length){
				GD.PushWarning("USED INVALID INITIAL SLIDE, DEFAULT TO 0");
				mInitialSlide = 0;
			}

			mSlideIndex = mInitialSlide;
			mActualSlide = ResourceLoader.Load<PackedScene>(mSlidesPaths[mInitialSlide]).Instantiate(); 
			
			this.AddChild(mActualSlide);
			PresentationSlide slide = (PresentationSlide) mActualSlide;
			slide.Initiate();

			slide.NextSlideRequest += LoadNextSlide;
			slide.PriorSlideRequest += LoadPreviousSlide;
		}

		// --------------------------------------------------------------------

		private void LoadIndexSlide(){
			Node newActualScene = ResourceLoader.Load<PackedScene>(mSlidesPaths[mSlideIndex]).Instantiate(); 
			
			PresentationSlide slide = (PresentationSlide) newActualScene;
			slide.Initiate();
			
			slide.NextSlideRequest += LoadNextSlide;
			slide.PriorSlideRequest += LoadPreviousSlide;

			mActualSlide.QueueFree();
			PresentationSlide priorSlide = (PresentationSlide) mActualSlide;
			priorSlide.NextSlideRequest -= LoadNextSlide;
			priorSlide.PriorSlideRequest -= LoadPreviousSlide;
			
			mActualSlide = newActualScene;

			this.AddChild(mActualSlide);
		}

		// --------------------------------------------------------------------

		public void LoadPreviousSlide(){
			if (mSlideIndex==0){
				return;
			}
			mSlideIndex--;
			LoadIndexSlide();
		}

		// --------------------------------------------------------------------

		public void LoadNextSlide(){
			if (mSlideIndex==mSlidesPaths.Length-1){
				return;
			}
			mSlideIndex++;
			LoadIndexSlide();
		}

		// --------------------------------------------------------------------

	}
}