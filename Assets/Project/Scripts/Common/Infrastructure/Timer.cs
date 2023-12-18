
namespace Project.Scripts.Common.Infrastructure
{
    public class Timer
    {
        public bool IsRunning { get; private set; }

        private float _passedTime;
        private float _targetTime;


        public Timer(float passedTime = 0f)
        {
            _passedTime = passedTime;
        }


        public void Launch(float seconds)
        {
            IsRunning = true;
            
            _targetTime = seconds;
            _passedTime = 0f;
        }

        public void Relaunch()
        {
            IsRunning = true;
            _passedTime = 0f;
        }
        
        public void Update(float timeStep)
        {
            _passedTime += timeStep;

            if (_passedTime > _targetTime)
                IsRunning = false;
        }
    }
}