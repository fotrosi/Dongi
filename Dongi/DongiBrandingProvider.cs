using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Dongi;

[Dependency(ReplaceServices = true)]
public class DongiBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Dongi";
}
