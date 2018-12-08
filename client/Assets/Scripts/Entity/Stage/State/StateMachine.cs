
using Entity.Stage;
using System.Collections.Generic;

public class StateMachine
{
    public List<State> stateList;

    public StateMachine()
    {
        stateList.Add(new StartState());
        stateList.Add(new EndState());
    }

    public void Update(Stage st)
    {

    }
}