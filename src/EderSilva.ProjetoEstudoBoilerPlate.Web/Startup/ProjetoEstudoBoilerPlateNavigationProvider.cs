using Abp.Application.Navigation;
using Abp.Localization;

namespace EderSilva.ProjetoEstudoBoilerPlate.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class ProjetoEstudoBoilerPlateNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "fa fa-home"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("About"),
                        url: "Home/About",
                        icon: "fa fa-info"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "CadeirasList",
                        L("CadeirasList"),
                        url: "Cadeiras",
                        icon: "fa fa-tasks"
                     )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ProjetoEstudoBoilerPlateConsts.LocalizationSourceName);
        }
    }
}
