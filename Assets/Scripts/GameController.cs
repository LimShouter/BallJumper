using Game.Ball;
using Game.Part;
using UI.GameScreen;
using UI.GameScreen.ScoreManager;
using UI.RematchScreen;
using UI.StartScreen;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GlobalContainer container;
    [SerializeField] private Player player;
    private BallPresenter _ballPresenter;

    private Environment _environment;
    private InputSystem _inputSystem;
    private PartsPresenter _partsPresenter;
    private ScorePresenter _scorePresenter;
    private StartScreenPresenter _startScreenPresenter;
    private GameScreenPresenter _gameScreenPresenter;
    private RematchPresenter _rematchPresenter;

    private void Start()
    {
        _environment = new Environment(player);
        _inputSystem = new InputSystem();
        _environment.PullCollection.PartPull.Init(player.partPullContainer);
        _partsPresenter = new PartsPresenter(_environment, _environment.PartsData);
        _startScreenPresenter = new StartScreenPresenter(_environment, _environment.StartScreenData, container.startScreenView);
        _gameScreenPresenter = new GameScreenPresenter(_environment.GameScreenData, container.gameScreenView);
        _rematchPresenter = new RematchPresenter(_environment, _environment.RematchData, container.rematchView);
        _ballPresenter = new BallPresenter(_environment.BallData, container.ballView);
        _scorePresenter = new ScorePresenter(_environment.ScoreData, container.gameScreenView.scoreView);

        _partsPresenter.Attach();
        _startScreenPresenter.Attach();
        _gameScreenPresenter.Attach();
        _rematchPresenter.Attach();
        _ballPresenter.Attach();
        _scorePresenter.Attach();
        _environment.StartScreenData.Show();
    }

    private void Update()
    {
        if (_environment.Player.Speed < _environment.Player.maxSpeed && _environment.PartsData.IsStarted) _environment.Player.Speed += _environment.Player.acceleration * Time.deltaTime;
        if (_environment.PartsData.IsStarted) _environment.PartsData.Update(_inputSystem.GetDifference() * _environment.Player.sensitivity);
    }
}