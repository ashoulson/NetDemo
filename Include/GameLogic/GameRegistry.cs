using Railgun;

namespace GameLogic
{
  public static class GameRegistry
  {
    public static void Initialize()
    {
      // TODO: This should be codegen
      RailRegistry registry = new RailRegistry();

      registry.SetCommandType<GameCommand>();
      registry.AddEntityType<ControlledEntity, EntityState>();
      registry.AddEntityType<DummyEntity, EntityState>();

      registry.Register();
    }
  }
}
