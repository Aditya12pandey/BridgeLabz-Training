using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.Datastructure.FitnessTracker
{
    internal interface IFitnessTracker
    {
        void AddUser(string name, int steps);
        void UpdateSteps(string name, int newSteps);
        void DisplayAllUsers();
        void SortByStepsDesc();
        void DisplayLeaderboard();
    }
}
