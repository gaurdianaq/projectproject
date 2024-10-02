using Godot;
using System;
using System.Collections.Generic;

//Do we want to have the splash screen config in a separate config file that is loaded at runtime? 
//TODO Ensure text and background image scale programmatically
//TODO Set background image programmatically
public partial class SplashScreen : Control
{
    private class ScreenData
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
    private int asciiNumCode;

    private List<ScreenData> possibleTitle = new List<ScreenData>();

    public override void _EnterTree()
    {
        possibleTitle.Add(new ScreenData("Booty Slayer", "A Pirates Hunt for Mimics"));
        possibleTitle.Add(new ScreenData("Living Chocolate Hunter", "Quest for Deliciousness"));
        possibleTitle.Add(new ScreenData("Trogdors Day Out", "Burnination Has Arrived!"));
    }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Random rnd = new Random();
        asciiNumCode = rnd.Next(33, 91);
        continueKey = (Key)asciiNumCode;
        int titleNum = rnd.Next(0, possibleTitle.Count);
        title = GetNode<Label>("Title");
        subTitle = title.GetNode<Label>("Subtitle");
        continueLbl = title.GetNode<Label>("Continue");
        title.Text = possibleTitle[titleNum].Title;
        subTitle.Text = possibleTitle[titleNum].Subtitle;
        continueLbl.Text = "Press " + (char)asciiNumCode + " to continue, any other key will result in termination";
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
    //TODO figure out how to handle combo keys for things like # or &, or just include a silly message telling the user they have poor luck and to restart the app
    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventKey eventKey)
        {
            if (eventKey.Pressed && eventKey.Keycode == continueKey)
            {
                GD.Print("you chose wisely");
                //TODO add scene transition logic
            }
            else if (eventKey.IsReleased() && eventKey.Keycode != continueKey && eventKey.Keycode != Key.Shift)
            {
                GD.Print("You have chosen termination");
                GetTree().Quit();
            }
        }
    }
}
