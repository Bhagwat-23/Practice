using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Footer
{
	public class FooterModule : IModule
	{
		IUnityContainer _unityContainer;
		IRegionManager _regionManager;
		public FooterModule(IUnityContainer unityContainer, IRegionManager regionManager)
		{
			this._unityContainer = unityContainer;
			this._regionManager = regionManager;
		}

		public void Initialize()
		{
			//this._unityContainer.Resolve<object,FooterStatusView>
		}
	}
}
