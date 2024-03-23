using Godot;
using System;

namespace PresentationFramework{
	public partial class BulletPoint : Control
	{

		// --------------------------------------------------------------------
		public override void _Ready()
		{
			this.Visible = false;
			this.SetProcess(false);
		}

		// --------------------------------------------------------------------

		public virtual void ShowBulletPoint(){
			this.Visible = true;
			this.SetProcess(true);
		}

		// --------------------------------------------------------------------

		public virtual void HideBulletPoint(){
			this.Visible = false;
			this.SetProcess(false);
		}

		// --------------------------------------------------------------------
	}
}
