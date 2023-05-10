using Dongi.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Dongi;

public abstract class DongiComponentBase : AbpComponentBase
{
    protected DongiComponentBase()
    {
        LocalizationResource = typeof(DongiResource);
    }
}
