using System.Collections.Generic;

public interface IDraftManagable
{
    string RegisterHarvester(List<string> arguments);

    string RegisterProvider(List<string> arguments);

    string Day();

    string Mode(List<string> arguments);

    string Check(List<string> arguments);

    string ShutDown();
}
