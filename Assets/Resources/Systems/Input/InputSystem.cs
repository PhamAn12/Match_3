

public class InputSystem : Feature
{
    public InputSystem(InputContext Input, GameContext gameContext)
    {
        Add(new InputMouseSystem(Input));
        Add(new ProcessInputSystem(Input, gameContext));
        //Add(new CheckDeleteSystem(gameContext));
    }
}
    