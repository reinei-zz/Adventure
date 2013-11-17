using libtcod;

namespace Adventure
{
	public class GameLoop
	{
		public static readonly GameLoop Game = new GameLoop();

		public static TCODConsole Console { get; private set; }

		private Screen Current;

		public void Setup()
		{
			Console = TCODConsole.root;
			Current = null;
		}

		public void Cycle(TCODKey k, TCODMouseData m)
		{
			this.Current.Render(k, m);
			this.Current.Handle(k, m);
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