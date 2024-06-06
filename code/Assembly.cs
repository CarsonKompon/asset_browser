global using Sandbox;
global using System.Collections.Generic;
global using System.Linq;

public class TestClass
{
    public async void Test()
    {
        var package = await Package.FetchAsync("carsonk.instagib", false);
        await package.MountAsync();
    }
}