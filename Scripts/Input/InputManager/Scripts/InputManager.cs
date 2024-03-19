using Godot;
using System;

namespace CoreCode.Scripts{
	public partial class InputManager : Node
	{

		// ----------------------------------- Information ------------------------------------------------
		/*This is a script to allow distribution of player input to different parts of the game.
		This include menus, characters and so on.
		
		// ------------------------------------ Use -------------------------------------------------------
		/* Put inputs reader as child nodes of this singleton. Then assign them to the mPlayerInputs array.
		Then actors of the game can just request their inputs or being assign by other means using this
		singleton methods*/

		// ------------------------------------- Singleton instantiation -------------------------------
		private static InputManager instance;
		public static InputManager Instance{
			get {return TryToReturnInstance();}
		}

		public static InputManager TryToReturnInstance(){
			if (instance == null){
				GD.PushWarning("instance of InputManager called before the instance was ready!");
				instance = new InputManager();
			}
			return instance;
		}


		public InputManager(){
			instance=this; 
		}


		// ------------------------------------ Variables-----------------------------------------

		[Export] private Godot.Collections.Array<NodePath> mPlayerInputs = new Godot.Collections.Array<NodePath>();

		public InputReaderVoid NullInputReader{
			get{return this.GetNode<InputReaderVoid>(mPlayerInputs[0]);}
		}

		//---------------------------------Methods------------------------------

		public void AssignInputByPlayerChannel(IControlableByInput controlable, int channel){
			controlable.RecieveInputReader(this.GetNode<InputReaderPlayer>(mPlayerInputs[channel]));
		}

		//-----------------------------------------------------------------

		public InputReaderAbstract GiveInputByPlayerChannel(IControlableByInput controlable, int channel){
			return this.GetNode<InputReaderPlayer>(mPlayerInputs[channel]);
		}
		
		//-----------------------------------------------------------------

		public void FreeInputFromControlable(IControlableByInput controlable){
			controlable.RecieveInputReader(this.GetNode<InputReaderAbstract>(mPlayerInputs[0]));
		}

	}
}
