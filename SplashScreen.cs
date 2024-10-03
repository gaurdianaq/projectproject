using Godot;
using System;
using System.Collections.Generic;

//Do we want to have the splash screen config in a separate config file that is loaded at runtime? 
//TODO Ensure text and background image scale programmatically
//TODO Set background image programmatically
public partial class SplashScreen : Control
{
	private struct ScreenData
	{
		public string Title { get; set; }
		public string Subtitle { get; set; }

		public ScreenData(string title, string subtitle)
		{
			Title = title;
			Subtitle = subtitle;
		}
	}

	private Label title;
	private Label subTitle;
	private Label continueLbl;

	private Key continueKey;

	private readonly Random rnd = new();
	private readonly List<ScreenData> possibleTitle = new()
	{ 
		new("Booty Slayer", "A Pirate's Hunt for Mimics"),
		new("Living Chocolate Hunter", "Quest for Deliciousness"),
		new("Trogdor's Day Out", "Burnination Has Arrived!")
	};

	public override void _EnterTree()
	{
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		title = GetNode<Label>("Title");
		subTitle = title.GetNode<Label>("Subtitle");
		continueLbl = title.GetNode<Label>("Continue");

		int asciiNumCode = rnd.Next(33, 91);
		int titleNum = rnd.Next(0, possibleTitle.Count);

		continueKey = (Key)asciiNumCode;
		continueLbl.Text = $"Press {(char)asciiNumCode} to continue, any other key will result in termination";

		title.Text = possibleTitle[titleNum].Title;
		subTitle.Text = possibleTitle[titleNum].Subtitle;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	//TODO figure out how to handle combo keys for things like # or &, or just include a silly message telling the user they have poor luck and to restart the app
	public override void _UnhandledInput(InputEvent inputEvent)
	{
		if (inputEvent is InputEventKey keyEvent)
		{
			if (keyEvent.Pressed && keyEvent.Keycode == continueKey)
			{
				GD.Print("you chose wisely");
				//TODO add scene transition logic
			}
			else if (keyEvent.IsReleased() && keyEvent.Keycode != continueKey && keyEvent.Keycode != Key.Shift)
			{
				GD.Print("You have chosen termination");
				GetTree().Quit();
			}
		}
	}
}
