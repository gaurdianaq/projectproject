using Godot;
using System;
using System.Collections.Generic;

//TODO Load Splash Screen Config
//TODO Ensure text and background image scale programmatically
//TODO Set background image programmatically
public partial class SplashScreen : Control
{
	private class ScreenData
	{	
		public string Title { get; set; }
		public string Subtitle { get; set; }

		public ScreenData(string title, string subtitle) {
			Title = title;
			Subtitle = subtitle;
		}

	}
	private Label title;
	private Label subTitle;

	private List<ScreenData> possibleTitle = new List<ScreenData>();

    public override void _EnterTree()
    {
        base._EnterTree();
		possibleTitle.Add(new ScreenData("Booty Slayer", "A Pirates Hunt for Mimics"));
		possibleTitle.Add(new ScreenData("Living Chocolate Hunter", "Quest for Deliciousness"));
		possibleTitle.Add(new ScreenData("Trogdors Day Out", "Burnination Has Arrived!"));

    }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		Random rnd = new Random();
		int titleNum = rnd.Next(0, possibleTitle.Count);
		title = GetNode<Label>("Title");
		subTitle = title.GetNode<Label>("Subtitle");
		title.Text = possibleTitle[titleNum].Title;
		subTitle.Text = possibleTitle[titleNum].Subtitle;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
