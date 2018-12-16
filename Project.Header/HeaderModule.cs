using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Project.Header.Interfaces;
using Project.Header.ViewModels;
using Project.Header.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Header
{
	public class HeaderModule : IModule
	{
		IUnityContainer _unityContainer;
		IRegionManager _regionManager;
		public HeaderModule(IUnityContainer unityContainer,IRegionManager regionManager)
		{
			this._unityContainer = unityContainer;
			this._regionManager = regionManager;
		}

		public void Initialize()
		{
			this._unityContainer.RegisterType<object, HeaderStatusView>(typeof(HeaderStatusView).Name, new ContainerControlledLifetimeManager());

			this._unityContainer.RegisterType<IHeaderStatus, HeaderStatusViewModel>(new ContainerControlledLifetimeManager());

			this._regionManager.RegisterViewWithRegion("HeaderView", typeof(HeaderStatusView));
		}
	}
}
