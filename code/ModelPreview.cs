using Sandbox;
namespace Browser;

public sealed class ModelPreview : Component
{
	[RequireComponent] public SkinnedModelRenderer Renderer { get; set; }
	[Property] public CameraComponent Camera { get; set; }

	public static ModelPreview Instance { get; private set; }

	public bool IsSpinning { get; set; } = true;
	TimeSince timeSinceRotation = 5f;

	protected override void OnAwake()
	{
		Instance = this;
	}

	protected override void OnUpdate()
	{
		if ( timeSinceRotation >= 3f && IsSpinning )
		{
			Transform.LocalRotation *= Rotation.FromYaw( Time.Delta * 25 );
		}
	}

	public void Drag( Rotation rotation )
	{
		Transform.LocalRotation *= rotation;
		timeSinceRotation = 0;
	}

	public void SetModel( Model model )
	{
		Renderer.Model = model;
		var bounds = Renderer.Bounds;
		var center = bounds.Center;
		var distance = bounds.Size.Length * 1.5f;
		Camera.Transform.Position = center + Camera.Transform.Rotation.Backward * distance;
	}
}
