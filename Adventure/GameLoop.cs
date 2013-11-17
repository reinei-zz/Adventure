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

		public void Init()
		{
			Console = TCODConsole.root;
			Current = null;
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
		public static MainMenu Main { get; private set; }

		public static void Init()
		{
			Main = new MainMenu();

			GameLoop.Game.SetScreen(Main);
		}
	}
}