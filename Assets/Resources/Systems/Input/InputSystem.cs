

public class InputSystem : Feature
{
    public InputSystem(GameContext Game)
    {
        Add(new InputMouseSystem(Game));        
    }
}
    