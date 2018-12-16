using Prism.Modularity;
using Prism.Unity;
using Project.Footer;
using Project.Header;
using Project.MainArea;
using Project.Shell;
using System.Windows;

namespace Project.LaunchApplication
{
	public class Bootstrapper:UnityBootstrapper
	{
		protected override DependencyObject CreateShell()
		{
			return Container.TryResolve<ProjectShell>();
		}

		protected override void InitializeShell()
		{
			base.InitializeShell();
			Window win = Shell as Window;
			if (win != default(Window))
				win.Show();
		}

		protected override IModuleCatalog CreateModuleCatalog()
		{
			return base.CreateModuleCatalog();
		}

		protected override void ConfigureModuleCatalog()
		{
			ModuleCatalog module = (ModuleCatalog)this.ModuleCatalog;
			module.AddModule(typeof(HeaderModule));
			module.AddModule(typeof(MainAreaModule));
			//module.AddModule(typeof(FooterModule));
			base.ConfigureModuleCatalog();
		}

		protected override void ConfigureContainer()
		{
			base.ConfigureContainer();
		}

	}
}
