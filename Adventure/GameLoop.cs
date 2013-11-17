using libtcod;

namespace Adventure
{
	public class GameLoop
	{
		public static readonly GameLoop Game = new GameLoop();

		public static TCODConsole Console { get; private set; }
		internal World world { get; private set; }

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

			//GameLogic stuff here
		}

		public void Draw()
		{
			this.Current.Draw();
		}
		
		public void SetScreen(Screen s)
		{
			this.Current = s;
		}
	}

	public class Screens
	{
		public static MainMenu MainMenu { get; private set; }
		public static WorldScreen WorldScreen { get; private set;}

		public static void Init()
		{
			MainMenu = new MainMenu();
			WorldScreen = new WorldScreen();

			GameLoop.Game.SetScreen(MainMenu);
		}
	}
}