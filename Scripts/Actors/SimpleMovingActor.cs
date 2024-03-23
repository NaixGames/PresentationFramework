using Godot;
using System;
using CoreCode.Scripts;


namespace PresentationFramework{
	public partial class SimpleMovingActor : Control, IControlableByInput
	{
		[Export] private float mMovingSpeed = 3f;
		private InputReaderAbstract mInput;

		// --------------------------------------------------------------------

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			mInput = InputManager.Instance.GiveInputByPlayerChannel(this, 0);

		}

		// --------------------------------------------------------------------

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
			int UpMovement = mInput.IsButtonPressed("Up")? -1 : 0;
			UpMovement += mInput.IsButtonPressed("Down")? 1 : 0;

			int RightMovement = mInput.IsButtonPressed("Right")? 1 : 0;
			RightMovement += mInput.IsButtonPressed("Left")? -1 : 0;


			Vector2 movement = new Vector2(mMovingSpeed*RightMovement, mMovingSpeed*UpMovement);
			this.Position += ((float)delta)*movement;
		}

		// --------------------------------------------------------------------

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