using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Project.MainArea.Interfaces;
using Project.MainArea.ViewModels;
using Project.MainArea.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MainArea
{
	public class MainAreaModule : IModule
	{
		IUnityContainer _unityContainer;
		IRegionManager _regionManager;
		public MainAreaModule(IUnityContainer unityContainer, IRegionManager regionManager)
		{
			this._unityContainer = unityContainer;
			this._regionManager = regionManager;
		}

		public void Initialize()
		{
			this._unityContainer.RegisterType<object, MainAreaView>(typeof(MainAreaView).Name, new ContainerControlledLifetimeManager());

			this._unityContainer.RegisterType<IMainAreaViewModel, MainAreaViewModel>(new ContainerControlledLifetimeManager());

			this._regionManager.RegisterViewWithRegion("MainAreaView", typeof(MainAreaView));
		}
	}
}
