using System.Windows;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using Microsoft.Practices.Prism.Events;
using Samba.Presentation.Services.Common;
using Samba.Presentation.Common.Widgets;

namespace Samba.Modules.EntityModule
{
    /// <summary>
    /// Interaction logic for ResourceSwitcherView.xaml
    /// </summary>

    [Export]
    public partial class EntitySwitcherView : UserControl
    {
        [ImportingConstructor]
        public EntitySwitcherView(EntitySwitcherViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();

            EventServiceFactory.EventService.GetEvent<GenericEvent<EventAggregator>>().Subscribe(
                x =>
                {
                    if (x.Topic == EventTopicNames.ActivateNavigation)
                    {
                        // When the MainMenu button was clicked
                        EntitySwitcherButtonsItemsControl.Visibility = Visibility.Visible;
                    }
                    else if (x.Topic == EventTopicNames.EntitySwitched)
                    {
                        // When the entity switcher button was clicked
                        EntitySwitcherButtonsItemsControl.Visibility = Visibility.Collapsed;
                    }

                });

            EventServiceFactory.EventService.GetEvent<GenericEvent<AppScreenChangeData>>().Subscribe(
                x =>
                {
                    if (x.Value.CurrentScreen.ToString() == "Navigation")
                    {
                        EntitySwitcherButtonsItemsControl.Visibility = Visibility.Visible;
                    }
                    else 
                    {
                        EntitySwitcherButtonsItemsControl.Visibility = Visibility.Collapsed;
                    }
                });
        }
    }
}
