using UnityEngine;


namespace Abduction.StateBehaviour
{
    /// <summary>
    /// Runs the state on a loop 
    /// </summary>
    public class StateMachine : MonoBehaviour
    {

        private State _state;

        
        private void Run()
        {
            _state.OnRun();

        }


        private void Swap()
        {
            _state.OnSwap();
        }


        public void SetChange(in State @state)
        {
            _state.OnSwap();

            _state = @state;
        }


        private void FixedUpdate()
        {
            Run();
        }


        private void Update()
        {
            Run();
        }

    }
}
