using Dongi.Localization;
using Volo.Abp.UI.Navigation;

namespace Dongi.Menus;

public class DongiMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<DongiResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                DongiMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        context.Menu.AddItem(
            new ApplicationMenuItem(
                DongiMenus.Persons,
                l["Menu:Persons"],
                url: "/Persons",
                icon: "fa fa-users"
            )
        );

        context.Menu.AddItem(
            new ApplicationMenuItem(
                DongiMenus.Persons,
                l["Menu:Transactions"],
                url: "/TxManager",
                icon: "fa fa-pen"
            )
        );

        // ter mohsen:
        //if (DongiModule.IsMultiTenant)
        //{
        //    administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        //}
        //else
        //{
        //    administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        //}

        return Task.CompletedTask;
    }
}
