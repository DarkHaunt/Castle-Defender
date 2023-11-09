namespace Project.Scripts.Common.Time
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
            Reset();

            _targetTime = seconds;
        }

        public void Update(float timeStep)
        {
            _passedTime += timeStep;

            if (_passedTime > _targetTime)
                IsRunning = false;
        }

        private void Reset()
        {
            IsRunning = true;

            _passedTime = 0f;
            _targetTime = 0f;
        }
    }
}