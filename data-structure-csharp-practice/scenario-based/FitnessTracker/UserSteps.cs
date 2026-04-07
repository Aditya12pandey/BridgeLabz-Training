using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.Datastructure.FitnessTracker
{
    internal class UserSteps
    {
        private string name;
        private int steps;

        public UserSteps(string name, int steps)
        {
            this.name = name;
            this.steps = steps;
        }

        public string Name => name;
        public int Steps => steps;

        public void SetSteps(int newSteps)
        {
            steps = newSteps;
        }

        public override string ToString()
        {
            return $"User: {name}, Steps: {steps}";
        }
    }
}
