using libtcod;

namespace Adventure
{
	public class GameLoop
	{
		public static readonly GameLoop Game = new GameLoop();

		public static TCODConsole Console { get; private set; }
		internal World world { get; private set; }

		public Entitys.Entity Player = null;
		public bool Run = true;
		private Screen Current;

		public void Init()
		{
			Console = TCODConsole.root;
			Current = null;
			world = new World();
		}

		public void Update(TCODKey k, TCODMouseData m)
		{
			this.Current.Update(k, m);			

			//Should exit?
			this.Run = this.Run && !TCODConsole.isWindowClosed();
			this.Run = this.Run && !(k.KeyCode == TCODKeyCode.Escape);
		}

		public void Draw()
		{
			this.Current.Draw();
		}
		
		public void SetScreen(Screen s)
		{
			this.Current = s;
		}

		public void Exit()
		{
			this.Run = false;
		}
	}

	public class Screens
	{
		public static Screen_Menu Menu { get; private set; }
		public static Screen_World World { get; private set;}
		public static Screen_Credits Credits { get; private set; }

		public static void Init()
		{
			Menu = new Screen_Menu();
			World = new Screen_World();
			Credits = new Screen_Credits();

			GameLoop.Game.SetScreen(Menu);
		}
	}
}