using libtcod;

namespace Adventure
{
	public class GameLoop
	{
		public static readonly GameLoop Game = new GameLoop();

		public static TCODConsole Console { get; private set; }

		private Screen Current;

		public bool ShouldPause()
		{
			return this.Current.Pause;
		}

		public void Setup()
		{
			Console = TCODConsole.root;
			Current = null;
		}

		public void Update(TCODKey k, TCODMouseData m)
		{
			GameLoop.Console.setForegroundColor(TCODColor.green);
			GameLoop.Console.setBackgroundColor(TCODColor.darkGrey);
			GameLoop.Console.clear();
			this.Current.Update(k, m);

			//GameLogic stuff here
		}

		public void Draw()
		{
			this.Current.Render();
		}
		
		public void SetScreen(Screen s)
		{
			this.Current = s;
		}
	}

	public class Screens
	{
		public static MainMenu Main { get; private set; }

		public static void Setup()
		{
			Main = new MainMenu();

			GameLoop.Game.SetScreen(Main);
		}
	}
}