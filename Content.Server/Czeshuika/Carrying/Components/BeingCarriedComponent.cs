namespace Content.Server.Czeshuika.Carrying.Components;

/// <summary>
/// Stores the carrier of an entity being carried.
/// </summary>
[RegisterComponent]
public sealed partial class BeingCarriedComponent : Component
{
    public EntityUid Carrier = default!;
}
