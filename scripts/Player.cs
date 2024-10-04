using Godot;

public partial class Player : CharacterBody2D
{
	[Export]
	public float Speed { get; set; } = 300.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 inputVec = Input.GetVector("left", "right", "up", "down");
		Velocity = inputVec.Normalized() * Speed;
		
		MoveAndSlide();
	}
}
