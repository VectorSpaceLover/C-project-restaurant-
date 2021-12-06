using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Regions;
using Samba.Presentation.Common;
using Samba.Presentation.Services;
using Samba.Presentation.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samba.Localization.Properties;

namespace Samba.Modules.AlltablesModule
{
    [ModuleExport(typeof(AllTablesModule))]
    public class AllTablesModule : VisibleModuleBase
    {
        private readonly IRegionManager _regionManager;
        private readonly AllTablesView _allTablesView;
        private readonly IUserService _userService;

        protected override void OnInitialization()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(AllTablesView));
        }

        [ImportingConstructor]
        public AllTablesModule(IRegionManager regionManager, AllTablesView allTablesView, IUserService userService)
            : base(regionManager, AppScreens.AllTables)
        {
            _regionManager = regionManager;
            _allTablesView = allTablesView;
            _userService = userService;

            //SetNavigationCommand("All Tables", Resources.Common, "Images/Run.png", 100);
            //PermissionRegistry.RegisterPermission(PermissionNames.OpenDashboard, PermissionCategories.Navigation, Resources.CanOpenDashboard);
        }

        public override object GetVisibleView()
        {
            return _allTablesView;
        }

        /*protected override bool CanNavigate(string arg)
        {
            return _userService.IsUserPermittedFor(PermissionNames.OpenDashboard);
        }*/

        protected override void OnNavigate(string obj)
        {
            base.OnNavigate(obj);
        }
    }
}
