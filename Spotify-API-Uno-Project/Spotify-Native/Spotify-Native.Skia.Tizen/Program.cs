using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace Spotify_Native.Skia.Tizen
{
	class Program
{
	static void Main(string[] args)
	{
		var host = new TizenHost(() => new Spotify_Native.App());
		host.Run();
	}
}
}
