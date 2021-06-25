using Game.Ball;
using Game.Part;
using UI.GameScreen;
using UI.GameScreen.ScoreManager;
using UI.RematchScreen;
using UI.StartScreen;
using Utility.Pull;

public class Environment
{
    public readonly BallData BallData;
    public readonly PartsData PartsData;
    public readonly Player Player;
    public readonly PullCollection PullCollection;
    public readonly ScoreData ScoreData;
    public readonly RematchData RematchData;
    public readonly StartScreenData StartScreenData;
    public readonly GameScreenData GameScreenData;

    public Environment(Player player)
    {
        Player = player;
        BallData = new BallData();
        GameScreenData = new GameScreenData();
        PullCollection = new PullCollection();
        StartScreenData = new StartScreenData();
        PartsData = new PartsData();
        RematchData = new RematchData();
        ScoreData = new ScoreData();
    }
}