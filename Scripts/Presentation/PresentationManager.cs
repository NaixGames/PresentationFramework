using Godot;
using System;

namespace PresentationFramework{
	public partial class PresentationManager : Node
	{
		[Export] private string[] mSlidesPaths;
		private int mSlideIndex=0;
		private Node mActualSlide;

		// --------------------------------------------------------------------

		public override void _Ready()
		{
			mActualSlide = ResourceLoader.Load<PackedScene>(mSlidesPaths[0]).Instantiate(); 
			this.AddChild(mActualSlide);
			PresentationSlide slide = (PresentationSlide) mActualSlide;
			slide.Initiate(this);
		}

		// --------------------------------------------------------------------

		private void LoadIndexSlide(){
			Node newActualScene = ResourceLoader.Load<PackedScene>(mSlidesPaths[mSlideIndex]).Instantiate(); 
			
			PresentationSlide slide = (PresentationSlide) newActualScene;
			slide.Initiate(this);
			
			mActualSlide.QueueFree();
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